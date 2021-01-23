    class Program
    {
        static void Main(string[] args)
        {
            BaseFoo foo = new Foo1();
    
            var bar = ConcreteClassFactory.CreateClass(ConcreteClassFactory.ConcreteClassType.ConcreteClass1);
    
            bar.SomeMethod(foo);
        }
    }
