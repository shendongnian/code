    /*Change your class definitions to use proper case names then use the camel case converter provide by newtonsoft*/
    public class WeatherClass
    {
        public string Name { get; set; }
        public Info Main { get; set; }
        public List<InfoWeather> Weather { get; set; }
    }
    public class Info
    {
        public string Temp { get; set; }
        public string Pressure { get; set; }
    }
    public class InfoWeather
    {
        public string Description { get; set; }
        public string Main { get; set; }
    }
    var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
    var weatherClass = Newtonsoft.Json.JsonConvert.DeserializeObject<WeatherClass>(json, jsonSerializerSettings);
