    public class Dto
    {
    #if !DEBUG
        [JsonProperty("l")]
    #endif    
        public string LooooooooooooongName { get; set; }
    }
    
