    public class Plugin1
    {
        public readonly IFoo Foo;
        public Plugin1(IFoo foo)
        {
            this.Foo = foo;
        }
    }
    public class Plugin2
    {
        public readonly IBar Bar;
        public readonly IBaz Baz;
        public Plugin2(IBar bar, IBaz baz)
        {
            this.Bar = bar;
            this.Baz = baz;
        }
    }
    public class Plugin3
    {
        public readonly IBar Bar;
        public readonly IBaz Baz;
        public Plugin3(IBar bar)
        {
            this.Bar = bar;
        }
        public Plugin3(IBar bar, IBaz baz)
        {
            this.Bar = bar; ;
            this.Baz = baz;
        }
    }
