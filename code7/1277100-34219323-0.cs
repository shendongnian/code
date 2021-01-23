    public static class YoursClass
    { 
        public const string AnotherHardCodedParam = "Foo";
    }
    public static class MyClass
    {
        private const string HardCodedParam = "FooBar";
        static MyClass()
        {
            DoStuff(MyClass.HardCodedParam);
            DoStuff(YoursClass.AnotherHardCodedParam);
        }
    }
