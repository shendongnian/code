    public class Foo
    {
        public static Foo GetInstance(int parameter)
        {
            if (FooCache.IsCached(parameter))
            {
                // return instance from cache
            }
            else
            {
                Foo instance = new Foo(parameter);
                // add to cache
                return instance;
            }
        }
        private Foo(int parameter)
        {
        }
    }
