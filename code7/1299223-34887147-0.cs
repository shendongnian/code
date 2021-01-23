    interface IEntity
    {
      IEnumerable<object> SomeTable { get; }
    }
    
    class DevEntity : IEntity
    {
      ...
    }
    
    class ProdEntity : IEntity
    {
      ...
    }
