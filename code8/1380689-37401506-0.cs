    public class RootObject
    {
        public List<PublicDataClass> body { get; set; }
        public string status { get; set; }
        public double time_exec { get; set; }
        public int time_server { get; set; }
    }
    public class PublicDataClass
    {
        public string _id { get; set; }
        public PublicData_Place place { get; set; }
        public int mark { get; set; }
        public List<string> modules { get; set; }
        public Dictionary<string, Measure> measures { get; set; }
    }
    public class PublicData_Place
    {
        public List<double> location { get; set; } // Changed from string to double
        public double altitude { get; set; } // Changed from string to double
        public string timezone { get; set; }
    }   
    public class Measure
    {
        public Measure()
        {
            this.Results = new Dictionary<string, List<double>>();
            this.Types = new List<string>();
        }
        [JsonProperty("res")]
        public Dictionary<string, List<double>> Results { get; set; }
    
        [JsonProperty("type")]
        public List<string> Types { get; set; }
    }
