    public class PartnerLoginOptions
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string DeviceModel { get; set; }
        public string Version { get; set; }
    
        [JsonIgnore]
        public OptionalBool IncludeUrls { get; set; }
        [JsonProperty("IncludeUrls")]
        public bool? IncludeUrlsConverted 
        { 
            get { return (bool?)IncludeUrls; } // your conversion here
            set { IncludeUrls = (OptionalBool)value; } // your backwards conversion here
        }
    }
