    public class Device
    {
        public List<Feature> Features { get; set; }
        public Feature PrimaryFeature { get; set; }
        // ...
    }
    public class Feature 
    { 
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public string Value { get; set; }
    }
