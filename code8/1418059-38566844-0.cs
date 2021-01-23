      [JsonObject]
      public class BankData
      {
        [JsonProperty(PropertyName = "Sync_Time")]
        public string Sync_Time { get; set; }
    
        [JsonProperty(PropertyName = "Bank_Code")]
        public string Bank_Code { get; set; }
    
        [JsonProperty(PropertyName = "Bank_Name")]
        public string Bank_Name { get; set; }
    
        [JsonProperty(PropertyName = "Status")]
        public int Status { get; set; }
      }
