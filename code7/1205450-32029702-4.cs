    public interface IMyInterface
    {
        void foo();
    }
    public class A : IMyInterface
    {
        public void foo()
        {
            Console.Out.WriteLine("A.foo() executed");
        }
    }
    public class B : A, IMyInterface
    {
        void IMyInterface.foo()
        {
            Console.Out.WriteLine("B.foo() executed");
        }
    }
