    void Main()
    {
      var dict = new Dictionary<MyClass, string>(new MyClassUniqueIdEqualityComparer());
      
      dict.Add(new UserQuery.MyClass { UniqueId = 1 }, "Hi!");
      
      dict.ContainsKey(new UserQuery.MyClass { UniqueId = 2 }).Dump(); // False
      dict.ContainsKey(new UserQuery.MyClass { UniqueId = 1 }).Dump(); // True
    }
    
    public class MyClass
    {
      public int UniqueId { get; set; }
    }
    
    public class MyClassUniqueIdEqualityComparer : IEqualityComparer<MyClass>
    {
      public bool Equals(MyClass a, MyClass b) 
      {
        return a.UniqueId == b.UniqueId;
      }
      
      public int GetHashCode(MyClass a)
      {
        return a.UniqueId.GetHashCode();
      }
    }
