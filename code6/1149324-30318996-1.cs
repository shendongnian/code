    public class Base {
        internal virtual string X() {
            return "Base";
        }
    }
    public class Derived1 : Base
    {
        internal new string X()
        {
            return "Derived 1";
        }
    }
 
    public class Derived2 : Base 
    {
        internal override string X()
        {
            return "Derived 2";
        }
    }
	Derived1 a = new Derived1();
    Base b = new Derived1();
    Base c = new Derived2();
    Console.WriteLine("Derived1 as Derived1: "+ a.X()); // Derived1 as Derived1: Derived 1
    Console.WriteLine("Derived1 as Base: " + b.X()); // Derived1 as Base: Base
    Console.WriteLine("Derived2 as Base: " + c.X()); // Derived2 as Base: Derived 2
