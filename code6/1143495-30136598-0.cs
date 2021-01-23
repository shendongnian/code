    class Program
    {
        static void Main(string[] args)
        {
            
            A test1 = new A();
            B test2 = new B();
            C test3 = new C();
            List<object> test4 = new List<object>() { test1, test2, test3 };
            List<object> test5 = test4.FindAll(x => x is A).ToList();
        }
    }
    public class A
    {
        public A() { }
    }
    public class B
    {
        public B() {}
    }
    public class C : A
    {
        public C()
            :base()
        {
        }
    }
