    public class Named 
    {
      public string Name { get; set; }
    }
    
    public class Foo : Named
    {
      public int MyProp { get; set; }
    }
    
    public class Bar : Named
    {
      public int MyProp { get; set; }
      public int MySecondProp { get; set; }
    }
    
    // ...
    
    Bar SomeMethod(Named source) 
    {
      // code, code, code...
      return source.ObjectToModel<Bar>();
    }
