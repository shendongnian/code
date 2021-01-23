    public class Person
        {
            [Key]
            public int PersonUID { get; set; }
    
            public string FirstName { get; set; }
    	    [JsonConverter(typeof(StringEnumConverter))]
            public EstadoPersona Status { get; set; }
    }
