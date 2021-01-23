    public class Foo
    {
        public int someVar { get; set; }
        public string anotherVar { get; set; }
    }
    public class Bar
    {
        public string nextVar { get; set; }
        public bool isThisAVar { get; set; }
    }
    public class Barfoo
    {
        public string first { get; set; }
        public int second { get; set; }
        public string third { get; set; }
    }
    public class Example
    {
        public Foo foo { get; set; }
        public Bar bar { get; set; }
        public string foobar { get; set; }
        public bool foobool { get; set; }
        public IList<Barfoo> barfoo { get; set; }
    }
