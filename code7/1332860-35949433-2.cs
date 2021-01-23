    public class DataDictionary 
    {
        public int Id { get; set; }
        public String Name { get; set; }
    
        public int? ParentId { get; set; }
    
        [JsonIgnore]
        public virtual DataDictionary Parent { get; set; }
    
        public ICollection<DataDictionary> Children { get; set; }
    }
