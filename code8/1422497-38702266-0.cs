    void Main()
    {
      typeof(A<>.Nested<>).GetGenericArguments().Dump();
    }
    
    public class A<T>
    {
      public class Nested<V>
      {
        
      }
    }
