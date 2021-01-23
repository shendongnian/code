    public class Derived<T>
    {
    }
    
    public abstract class Derivable<T>
    {
        public Derived<T> CreateDerived()
        {
            return new Derived<T>();
        }
    }
    
    public class Foo : Derivable<Foo>
    {
    }
    
    class Visitor
    {
        public static void Visit<T>(Derived<T> obj)
        {
            Console.Out.WriteLine("Called!");
        }
    }
    
    void Main()
    {
        var obj = new Foo();
        var derived = obj.CreateDerived();
        Visitor.Visit(derived);
    }
