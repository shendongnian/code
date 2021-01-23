    interface IZar<TFoo> where TFoo : IFoo
    {
        void Add(TFoo foo);
    }
    class ZarFoo : IZar<Foo>
    {
        public void Add(Foo foo)
        { }
    }
    class ZarBar : IZar<Bar>
    {
        public void Add(Bar foo)
        { }
    }
