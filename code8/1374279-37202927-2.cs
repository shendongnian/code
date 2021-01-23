    public interface IMyInterface
    {
    }
    
    public class A : IMyInterface
    {
        internal A() // so, the user/developer won't be able to call "var a = new A()" outside of the scope of the assembly
        {
        }
    }
    
    public class B : IMyInterface
    {
        internal B()
        {
        }
    }
    
    public static class MyFactory
    {
        public static IMyInterface CreateA()
        {
            return new A();
        }
    
        public static IMyInterface CreateB()
        {
            return new B();
        }
    }
