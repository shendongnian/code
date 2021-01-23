    var json = "{\"arr\": [1, 2]}";
    public class Poco
    {
        public List<string> Arr { get; set; }
    }
    var dto = json.FromJson<Poco>();
