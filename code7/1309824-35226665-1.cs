    public class DynamicData
        {
            public int Id { get; set; }
    
            public virtual ICollection<DynamicDataValue> Values { get; set; } 
        }
    
        public class DynamicDataValue
        {
            public int Id { get; set; }
            public string Value { get; set; }
        }
