    public class Base
    {
        public void DoSomething()
        {
            Console.WriteLine("Base.DoSomething");
        }
    }
    public class Derived : Base
    {
        public void DoSomething()
        {
            Console.WriteLine("Derived.DoSomething");
        }
    }
