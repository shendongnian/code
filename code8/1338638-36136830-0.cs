    public class Program
    {
        public static void Main(string[] args)
        {
            var bar = new Bar();
            TestMethod(bar);
            TestMethod2(bar);
        }
        public static void TestMethod<T>(T obj) where T : Foo
        {
            obj.Test();
        }
        public static void TestMethod2<T>(T obj) where T : Bar
        {
            obj.Test();
        }
    }
    public class Foo
    {
        public virtual void Test()
        {
            Debugger.Break();
        }
    }
    public class Bar : Foo
    {
        public new void Test()
        {
            Debugger.Break();
        }
    }
