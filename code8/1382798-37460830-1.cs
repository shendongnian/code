    public class Request
    {
        [
           JsonProperty(NullValueHandling = NullValueHandling.Ignore, 
                        ItemConverterType = typeof(TrimmingConverter))
        ] 
        public string Description { get; set; }
    }
