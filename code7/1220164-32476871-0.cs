    static void Main(string[] args)
    {
        System.Console.WriteLine(Constants.ChildA.Current);
        System.Console.WriteLine(Constants.ChildB.SomeOtherParameter);
        System.Console.WriteLine(Constants.ChildA.SomeParameter);
    }
    public static class Constants
    {
        public static class ChildA
        {
            public const string Current = "Child A";
            public const string SomeParameter = "Some parameter";
            public const string SomeOtherParameter = "Some other parameter";
        }
        public static class ChildB
        {
            public const string Current = "Child B";
            public const string SomeParameter = "Some different parameter";
            public const string SomeOtherParameter = "Some parameter";
        }
    }
