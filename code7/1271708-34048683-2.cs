    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            { 
                ""stops"": 
                [
                    [0.1, ""#55BF3B""],
                    [0.5, ""#DDDF0D""],
                    [0.9, ""#DF5353""]
                ]
            }";
            RootObject obj = JsonConvert.DeserializeObject<RootObject>(json);
            foreach (Stop stop in obj.Stops)
            {
                Console.WriteLine("Value: " + stop.Value);
                Console.WriteLine("Color: " + stop.Color);
                Console.WriteLine();
            }
            json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
    class RootObject
    {
        [JsonProperty("stops")]
        public List<Stop> Stops { get; set; }
    }
    [JsonConverter(typeof(StopConverter))]
    public class Stop
    {
        public decimal Value { get; set; }
        public string Color { get; set; }
    }
