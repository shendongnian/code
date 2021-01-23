    [JsonConverter(typeof(PersonConverter))]
    public class Person
    {
        public string First { get; set; }
        public string Last { get; set; }
        public string Age { get; set; }
    }
