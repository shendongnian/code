    [DataContract] 
    public class Class
              {
          [DataMember]
          public string Model { get; set; }
          [DataMember]
          public DateTime Year { get; set; }
          // ignored
          public List<string> Features { get; set; }
          public DateTime LastModified { get; set; }
        }
