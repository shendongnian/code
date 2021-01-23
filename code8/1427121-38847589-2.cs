    public static class ClassC
    {
        public static void Method1()
        {
            Console.WriteLine("ClassC.Method1()");
        }
        public static void Method2()
        {
            Console.WriteLine("ClassC.Method2()");
        }
    }
    public class ClassCImpl : IClassC
    {
        public void Method1()
        {
            ClassC.Method1();
        }
        public void Method2()
        {
            ClassC.Method2();
        }
    }
