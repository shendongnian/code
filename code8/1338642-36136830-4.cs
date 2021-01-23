    public static void TestMethod<T>(T obj)
    {
        ((Foo)obj).Test(); //You would expect this to call Foo.Test() b\c of shadowing
        ((Foo)obj).Test2(); //You would expect this to call Bar.Test2() b\c of overloading
    }
