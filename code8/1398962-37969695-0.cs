    public class Account
     {
     public string EmailAddress { get; set; }
 
     // appear last
     [JsonProperty(Order = 1)]
     public bool Deleted { get; set; }
 
     [JsonProperty(Order = 2)]
      public DateTime DeletedDate { get; set; }
      public DateTime CreatedDate { get; set; }
      public DateTime UpdatedDate { get; set; }
      // appear first
      [JsonProperty(Order = -2)]
      public string FullName { get; set; }
    }
