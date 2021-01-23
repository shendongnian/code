    public class ObjectA 
    {
         public int ObjectAId { get; set; }
         public virtual ICollection<ObjectC> ObjectCCollection { get; set; }
    }
    
    public class ObjectC 
    {
         public int? ObjectAId { get; set; } 
         public virtual ObjectA ObjectA { get; set; }
    }
