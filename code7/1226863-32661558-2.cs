    public class Principal
    {
       [Key]
       public int Id {get;set;}
       public virtual Dependent Dependent{get;set;}
    }
    
    public class Dependent
    {
      [Key,ForeignKey("Principal")]
      public int PrincipalId {get;set;}
      public virtual Principal Principal{get;set;}
    }
