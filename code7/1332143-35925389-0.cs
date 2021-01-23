    public class Foo
    {
        private readonly object _bar;
        private readonly Lazy<int> _lazyInt; 
        public Foo(object bar)
        {
            _bar = bar;
            _lazyInt = new Lazy<int>(() => GetLazyObject(_bar));
        }
        private static int GetLazyObject(object init)
        {
            return init.GetHashCode();
        }
    }
