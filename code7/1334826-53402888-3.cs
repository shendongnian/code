    public class Parent
    {
       public int ChildId {get; set; }
    
       [ForeignKey("ChildId")]
       public virtual Child Child { get; set; }
    }
