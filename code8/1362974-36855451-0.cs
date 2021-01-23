    public class Record
    {
      [JsonProperty(PropertyName = "form_id")]
      public string FormId { get; set; }
      
      [JsonProperty(PropertyName = "status")]
      public string Status { get; set; }
    
      [JsonProperty(PropertyName = "latitude")]
      public decimal Latitude { get; set; }
    
      [JsonProperty(PropertyName = "longitude")]
      public decimal Longitude { get; set; }
    
      [JsonProperty(PropertyName = "form_values")]
      public Dictionary<string, string> FormValues { get; set; }
    }
    
    public class RecordContainer
    {
      [JsonProperty(PropertyName = "record")]
      public Record Record { get; set; }
    }
