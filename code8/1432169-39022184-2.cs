    [Table("AuditPoints")
    public class AuditPoint
    {
       [Key]
       public AuditPointID { get; set;}
       public List<AutoPoint> AutoPoints { get; set;}
    
    } 
    
    public class AutoPoint
    {
       public AutoPointID { get; set; }
       public Name { get; set; }
    }
