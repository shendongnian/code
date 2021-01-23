    public class Foo
    {
        public int FooNumber {get;}
    
        internal Foo(int fooNumber)  // internal so only clients within the same assembly can use it
        { 
            FooNumber = fooNumber;
        }
    }
    
    public static class FooGenerator()
    {
      public static Dictionary<int, Foo> instances = new Dictionary<int, Foo>();
      public static Foo GetFoo(int fooNumber)
      {
        if(!instances.ContainsKey(fooNumber))
           // this Foo has not yet been created, so create and add it
           instances.Add(fooNumber,new Foo(fooNumber));
      }
      // pull the Foo from the list by fooNumber
      return instances[fooNumber];
    }
