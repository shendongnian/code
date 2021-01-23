    public class Event
    {
        public string title { get; set; }
        public string date { get; set; }
        public string notes { get; set; }
        public bool bunting { get; set; }
    }
    
    public class EnglandAndWales
    {
        public string division { get; set; }
        public List<Event> events { get; set; }
    }
    
    public class Scotland
    {
        public string division { get; set; }
        public List<Event> events { get; set; }
    }
    
    public class NorthernIreland
    {
        public string division { get; set; }
        public List<Event> events { get; set; }
    }
    
    public class RootObject
    {
        [JsonProperty(PropertyName = "england-and-wales")]
        public EnglandAndWales EnglandAndWales { get; set; }
        public Scotland scotland { get; set; }
        [JsonProperty(PropertyName = "northern-ireland")]
        public NorthernIreland NorthernIreland { get; set; }
    }
