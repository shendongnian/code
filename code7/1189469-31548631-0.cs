    public class PropertyClass<T>
    {
      public List<T> Settings { get; set; }
    
      public PropertyClass()
      {
        Settings = new List<T>();
      }
    ...
    }
    
    PropertyClass<MyProperty> pc = new PropertyClass<MyProperty>();
