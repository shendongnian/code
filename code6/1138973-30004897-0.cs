    interface IA<T>
    {
        T Foo();
    }
    
    class Baz1 { }
    class Baz2 { }
    
    class Bar : IA<Baz1>, IA<Baz2>
    {
        Baz2 IA<Baz2>.Foo()
        {
            return new Baz2(); 
        }
    
        Baz1 IA<Baz1>.Foo()
        {
            return new Baz1(); 
        }
    }
    
