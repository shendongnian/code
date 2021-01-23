    using System;
    
    interface IFoo<T> {}
    
    public class Foo1<T> : IFoo<T> {}
    public class Foo2<T> : IFoo<T> {}
    
    class Test
    {
        static void Main()
        {
            var type1 = typeof(Foo1<>).GetInterfaces()[0];
            var type2 = typeof(Foo2<>).GetInterfaces()[0];
            
            Console.WriteLine(type1);
            Console.WriteLine(type2);
            Console.WriteLine(type1.Equals(type2));
        }
    }
