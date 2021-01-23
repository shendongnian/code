    public class Person
    {
      public int Id { get;set;}
      public string Name { get;set;}
      
      [ForeignKey("Office")]
      public int OfficeId { get; set; }
      public virtual Office WorkingAt { get;set;}
    }
