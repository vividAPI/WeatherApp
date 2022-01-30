using ClassLibrary;
using System.Text.Json;


bool more = true;
do
{
    try
    {

        Console.Write("Hello, what city are you interested in? ");


        string? city = Console.ReadLine();
        string key = "feb5ef54e7831316166cf5ab9116a006";

        var url = new Uri($"https://api.openweathermap.org/data/2.5/weather?q={city}&units=imperial&appid={key}");

        HttpClient client = new HttpClient();
        client.BaseAddress = url;

        string foo = await client.GetStringAsync(url);

        WeatherModel.Root? jsonString = JsonSerializer.Deserialize<WeatherModel.Root>(foo);

        Console.WriteLine($"The weather in {city} feels like {jsonString.main.feels_like} degrees F and the Latitude is {jsonString.coord.lat} and the Logitude is {jsonString.coord.lon}");
        Console.Write("Would you like to see another city? Y/N: ");
        string? response = Console.ReadLine();
        if (response.ToLower() == "y")
        {
            more = true;
        }
        else
        {
            more = false;
        }

    }
    catch (Exception e)
    {

        Console.WriteLine("You did something weird, not sure what? Maybe try another city?");
    }
} while (more);

