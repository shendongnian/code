    public class Principal
    {
      [Key]
      public Guid Id{get;set;}
    
      public virtual Dependent Dependent{get;set}
    }
    
    public class Dependent
    {
      [Key,ForeignKey("Principal" )]
      public Guid PrincipalId{get;set;}
    
      public virtual Principal Principal{get;set}
    }
