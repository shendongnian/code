    public class Letter 
    {
        [Required]
        public string Content {get; set;}
    
        [Required]
        [EnumDataType(typeof(Priority))]
        [JsonConverter(typeof(StringEnumConverter))]
        public Priority Priority {get; set;}
    }
