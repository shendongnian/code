    public class Base
    {
        public virtual void DoSomething()
        {
            Console.WriteLine("Base.DoSomething");
        }
    }
    public class Derived : Base
    {
        public override void DoSomething()
        {
            Console.WriteLine("Derived.DoSomething");
        }
    }
