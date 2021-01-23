    public class A
    {
        public void foo()
        {
            Console.WriteLine("A.foo()");
        }
        public void foo2()
        {
            Console.WriteLine("A.foo2()");
        }
        public static void bar()
        {
            Console.WriteLine("A.bar()");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            Action action = a.foo;
            action += a.foo2; 
            MulticastDelegate d = (MulticastDelegate)action;
            Debug.Assert(object.ReferenceEquals(d.Target, a)); // passes
            action();
            action = A.bar;
            d = (MulticastDelegate)action;
            Debug.Assert(object.ReferenceEquals(d.Target, null)); // passes
            action();
        }
    }
