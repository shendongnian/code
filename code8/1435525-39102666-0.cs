    [Serializable]
    public class ValueAdds2
    { 
        public ValueAdd ValueAdd { get; set; }
    
        [JsonProperty(PropertyName = "@size")]
        public string Size { get; set; }
    }
