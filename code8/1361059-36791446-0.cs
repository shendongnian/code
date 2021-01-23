    public static class TestClass
    {
        public static void Test<T>(T something) { }
    }
    TestClass.Test("something");// T is infered.
