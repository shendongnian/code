    public class Person
    {
      public int Id { get;set;}
      public string Name { get;set;}      
      
      public int OfficeId { get; set; }
      
      [ForeignKey("OfficeId")]
      public virtual Office WorkingAt { get;set;}
    }
