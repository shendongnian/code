    public class Foo
    {
        public static void FooMethod() { }
    }
    public class Bar : Foo
    {
        public Bar()
        {
            FooMethod();
        }
    }
