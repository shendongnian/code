    public class Foo
    {
        public Foo(Func<Foo> fooFactory)
        {
            this._fooFactory = fooFactory;
        }
        private readonly Func<Foo> _fooFactory;
        public void Do()
        {
            Foo f = this._fooFactory();
            f.Do();
        }
    }
