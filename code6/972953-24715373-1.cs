    public class B
    {
        public void foo()
        {
            Console.WriteLine("B.foo()");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            Action action = a.foo;
            action += a.foo2;
            action += b.foo;
            MulticastDelegate d = (MulticastDelegate)action;
            Debug.Assert(object.ReferenceEquals(d.Target, b)); // passes
            action();
            action = A.bar;
            d = (MulticastDelegate)action;
            Debug.Assert(object.ReferenceEquals(d.Target, null)); // passes
            action();
        }
    }
