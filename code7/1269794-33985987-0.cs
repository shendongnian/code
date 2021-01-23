    public class Parent
    {
      public Parent()
      {
        Children = new List<child>(); 
        parentId = Guid.NewGuid(); 
      }
      [Key]
      public Guid parentId { get; set; }
      [Required]
      [StringLength(4)]
      public string parentData { get; set; }
      public virtual List<Child> Children { get; set; }
    }
    public class Child
    {
      public Child()
      {
       childId = Guid.NewGuid();
      }
      [Key]
      public Guid childId { get; set; }
      [ForeignKey("Parent")]
      public Guid parentId { get; set; }
      [Required]
      [StringLength(65)]
      public string childData { get; set; }
      public virtual Parent Parent { get; set; }
    }
