    public class EntityJson
    {
      int Id { get; set; }
      int Checksum { get; set; }
      public string Name { get; set; }
      public bool Hair { get; set; }
    }
    // quick/poor example
    public class EntityAdapter : IEntity
    {
      public EntityAdapter(EntityJson model)
      {
        Header = new Header(); // and populate this objects fields
        Name = model.Name; // populate other properties
      }
      public EntityHeader Header { get; set; }
      public string Name { get; set; }
      public bool Hair { get; set; }
      
    }
