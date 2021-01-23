    public class Middle
    {
        readonly int foo;
        public int Foo { get { return foo; } }
        public Middle(int Foo) { this.foo = Foo; "Middle".Dump(); }
        public Root Root { get; set; }
        public Child Child { get; set; }
    }
