    partial class Customer
    {
        [JsonIgnore]
        public bool IncludeCustomerId {get;set;}
        [JsonProperty]
        public string Name { get; set; }
    
        [JsonProperty]
        public string Address{ get; set; }
    
        [JsonProperty]
        public string CardInfo { get; set; }         
    
        public int CustomerId { get; set; }
        public bool ShouldSerializeCustomerId()
       {
           
          return IncludeCustomerId;
       }
    }
