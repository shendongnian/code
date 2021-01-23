    public interface IFoo
    {
        void Method1();
        void Method2();
    }
    
    public class Foo : IFoo
    {
        public void Method1()
        {
            Console.WriteLine("I am Method1 of Foo");
        }
        public void Method2()
        {
            Console.WriteLine("I am Method2 of Foo");
        }
    }
