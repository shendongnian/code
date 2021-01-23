    class Addresses
    {
        public int ID { get; set; }
        [JsonIgnore]
        public virtual Something Something { get; set; }
    }
  
