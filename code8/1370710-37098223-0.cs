    public class Base
    {
        public virtual void DoIt()
        {
            Console.WriteLine("Base.DoIt was called!");
        }
    }
    public class Derived : Base
    {
        public override void DoIt()
        {
            Console.WriteLine("Derived.DoIt was called!");
        }
    }
    public class Derived1 : Derived
    {
        public new void DoIt()
        {
            Console.WriteLine("Derived1.DoIt was called!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Base b = new Derived();
            Derived d = new Derived();
            Console.WriteLine("#1");
            b.DoIt();                      
            Console.WriteLine("#2");
            d.DoIt();                     
            b = new Derived1();
            d = new Derived1();
            Console.WriteLine("#3");
            b.DoIt();                    
            Console.WriteLine("#4");
            d.DoIt();
            Console.WriteLine("#5");
            Derived1 e = new Derived1();
            e.DoIt();
            Console.ReadKey();
        }
    }
