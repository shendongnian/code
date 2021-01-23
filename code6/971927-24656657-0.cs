    public class MyClass
    {
        public Method1()
        {
        }
    }
    public static class MyClassExt
    {
        public static Method2(this MyClass myClass)
        {
        }
    }
    MyClass mc = new MyClass();
    mc.Method1();
    mc.Method2();
