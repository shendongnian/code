    public class Definition
    {
       public int Id { get; set; }
       public ICollection<ChildrenDefinition> ChildrenDefinitions{ get; set; }
    }
    public class ChildrenDefinition
    {
      public int DefinitionId { get; set; }
      public Definition Definition { get; set; }
      public int ChildrenId { get; set; }
      public Children Children { get; set; }
    }
    public class Children
    {
        public int Id { get; set; }
        public ICollection<ChildrenDefinition> ChildrenDefinitions{ get; set; }
    }
