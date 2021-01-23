    public static class Extensions
    {
        public static object Method2(this Base b)
        {
            return null;
        }
    }
    public class Base 
    {
        public void Method1()
        {
        }
    }
    public class Derived:Base
    {
        public void Test()
        {
            base.Method1();
            base.Method2(); // Does not contain a definition
        }
    }
