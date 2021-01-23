    class Program
    {
        static void Main(string[] args)
        {
            var b = new BaseClass();
            var d = new DerivedClass();
            var f = new foo(d);
            //prints Derived Constructor
            var e = new foo(b);
            //prints Base Constructor
        }
    }
    public class BaseClass {
       public BaseClass()
        {
        }
    }
    public class DerivedClass : BaseClass
    {
        public DerivedClass()
        {
        }
    }
    class foo
    {
        public foo(DerivedClass bar)
        {
            //do one thing
            Console.WriteLine("Derived Constructor");
        }
        public foo(BaseClass bar)
        {
            Console.WriteLine("Base Constructor");
        }
    }
