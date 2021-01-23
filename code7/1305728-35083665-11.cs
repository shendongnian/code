    public static class Extensions
    {
        public static void Method2(this Base b) ...
    }
    public class Base 
    {
        public void Method1() ...
    }
    public class Derived:Base
    {
        public void Test()
        {
            base.Method1();
            base.Method2(); // Does not contain a definition
        }
    }
