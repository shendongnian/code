    struct Foo
    {
        public DateTime Created;
        public DateTime Modified;
        public Foo(DateTime dt)
        {
            Created = Modified = dt;
        }
    }
    var foo = new Foo(DateTime.Now);
