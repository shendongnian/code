    [Bind(Exclude="Foo")]
    class MyViewModel
    {
        public string Stuff { get; set; }
        public IFoo Foo { get; set; }
    }
