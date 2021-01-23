    public class MyClass
    {
      public int x;
      public object o;
    }
    public static IEnumerable<MyClass> Parse(Object obj)
    {
        MyClass c = new MyClass();
        c.x += 10;
        c.o  = <some new object>
        // Add c to instance of List<MyClass>
        return new List<MyClass>();
    }
    
    public static void Query(List<Object> obj)
    {          
        var result = obj
            .AsParallel()
            .Select(o => Parse(o))
       
       // result is of type IEnumerable<MyClass>
       var sum = result.Sum(a=>a.x);
 
       var aggregate = result.Aggregate((a, b) => a.o.Concat(b.o));
    }
