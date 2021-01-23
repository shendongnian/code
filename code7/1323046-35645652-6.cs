    public enum CustomType
    {
        Food,
        Place,
        Weight
    }
    
    public class Item
    {
        public int ID { get; set; }
        public string ASSET_NAME { get; set; }
        public virtual ICollection<Field> fields { get; set; }
    
        [NotMapped]
        public Field Food { get { return fields == null ? null : fields.Where(x => x.Type == CustomType.Food).FirstOrDefault(); } }
        [NotMapped]
        public Field Place { get { return fields == null ? null : fields.Where(x => x.Type == CustomType.Place).FirstOrDefault(); } }
        [NotMapped]
        public Field Weight { get { return fields == null ? null : fields.Where(x => x.Type == CustomType.Weight).FirstOrDefault(); } }
    }
    
    public class Field
    {        
        public int ID { get; set; }
        public string STRINGVAL { get; set; }
        public CustomType Type { get; set; }
    
        public virtual Item Item { get; set; }
    }
