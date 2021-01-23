    public class Wrapper
    {
        public Cars Cars { get; set; }
    }
    public class Cars
    {
        public Car[] Car { get; set; }
    }
    public class Car
    {
        [JsonProperty(PropertyName = "car_name")]
        public string Name { get; set; }
        public string Country { get; set; }
        public Engines Engines { get; set; }
    }
    public class Engines
    {
        public Engines()
        {
            Engine = new Engine[0];
        }
        // We need to use a custom JSON converter
        // because of this pretty broken schema that you have
        // in which the engine property can be array and a standard
        // object at the same time
        [JsonConverter(typeof(EnginesConverter))]
        public Engine[] Engine { get; set; }
    }
    public class Engine
    {
        public string Name { get; set; }
    }
