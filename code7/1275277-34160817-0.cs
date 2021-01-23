    public class DTO
    {
       [JsonIgnore]
       public int Id {get;set;}
       [JsonProperty("Id")]
       public int ServerId {get;set;}
    }
