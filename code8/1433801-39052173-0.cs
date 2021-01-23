    public static async Task<string> UpdateWeather(string lat, string lon)
    {
        WeatherObject weather = await WeatherAPI.GetWeatherAsync(lat, lon);
    
        var first = weather.list.Where(l => l.weather.Any(w => w.id == 800))
                                .Select(l => l.city.name)
                                .FirstOrDefault();
                                     
        return first;
    }
