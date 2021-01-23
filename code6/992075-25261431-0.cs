    private static void Dosomething(string Name)
    {
        { Name = Name };//Assignment made to same variable error
        var test = new TestClass{ Name = Name };//Works fine
    }
    class TestClass
    {
        public string Name { get; set; }
    }
