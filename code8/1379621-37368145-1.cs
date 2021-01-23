    public class DailyWeatherDTO  // root-level container object
    {
        public DailyWeatherData daily { get; set; }
    }
    
    public class DailyWeatherData
    {
        public string summary { get; set; }
        public string icon { get; set; }
        public List<WeatherItem> data { get; set; }
    }
    
    public class WeatherItem
    {
        public int time { get; set; }
        public string summary { get; set; }
        public string icon { get; set; }
        public int sunriseTime { get; set; }
        public int sunsetTime { get; set; }
        public double moonPhase { get; set; }
        public int precipIntensity { get; set; }
        public int precipIntensityMax { get; set; }
        public int precipProbability { get; set; }
        public double temperatureMin { get; set; }
        public int temperatureMinTime { get; set; }
        public double temperatureMax { get; set; }
        public int temperatureMaxTime { get; set; }
        public double apparentTemperatureMin { get; set; }
        public int apparentTemperatureMinTime { get; set; }
        public double apparentTemperatureMax { get; set; }
        public int apparentTemperatureMaxTime { get; set; }
        public double dewPoint { get; set; }
        public double humidity { get; set; }
        public double windSpeed { get; set; }
        public int windBearing { get; set; }
        public int cloudCover { get; set; }
        public double pressure { get; set; }
        public double ozone { get; set; }
    }
