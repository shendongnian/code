    [Serializable]
    public class ValueAdds
    { 
     public dynamic ValueAdd { get; set; }
     [JsonProperty(PropertyName = "@size")]
     public string Size { get; set; }
    }
