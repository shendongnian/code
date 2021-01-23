    public class KeyValue {
        public int Id { get; set; } 
        public string Key { get; set; }
        public bool Value { get; set; }
        public Testimonial Testimonial { get; set; }
    }
    
    public class Testimonial{
        public int Id { get; set; } 
        public virtual ICollection<KeyValue> Dictionary { get; set; }
    }
