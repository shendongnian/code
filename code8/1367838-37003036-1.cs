    interface IZar<out TFoo> where TFoo : IFoo
    {
        TFoo GetOne();
    }
    class ZarFoo : IZar<Foo>
    {
        public Foo GetOne()
        { return new Foo(); }
    }
    class ZarBar : IZar<Bar>
    {
        public Bar GetOne()
        { return new Bar(); }
    }
