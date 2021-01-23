    [DataContract]
    [Serializable]
    public abstract class OrderBase
    {
        public OrderBase(DatabaseObject obj)
        {
            this.Id = obj.Id;
            this.Name = obj.Name;
            this.Description = obj.Description;
            this.ClosingDate = obj.ClosingDate;
            this.Price = obj.Price;
        }
    
        [DataMember]
        public string Id { get; set; }
    
        [DataMember]
        public string Name { get; set; }
    
        [DataMember]
        [JsonIgnore]
        public string Description { get; set; }
    
        [DataMember]
        [JsonIgnore]
        public decimal Price { get; set; }
    
        [DataMember]
        [JsonIgnore]
        public string ClosingDate { get; set; }
    }
