    //  Assume that Whoop declares Bar and initializes it in its constructor
    class Foo : Whoop {
        public Foo(int bar = 0) : base(bar) {}
        public Foo(int bar, string baz) : this(bar) { Baz = baz; }
                                        //  C#6
        public String Baz { get; set; } = "yabba dabba do";
    }
