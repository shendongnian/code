    class TestClass
    {
        public int Int { get; set; }
        public string Str { get; set; }
    }
    
    TestClass t = new TestClass();
    object ob = new TestClass();
    
    Console.WriteLine(((TestClass)ob).Str );
