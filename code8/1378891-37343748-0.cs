     public class Class
          {
          // included in JSON
      public string Model { get; set; }
      public DateTime Year { get; set; }
      public List<string> Features { get; set; }
     
       // ignored
      [JsonIgnore]
      public DateTime LastModified { get; set; }
    }
