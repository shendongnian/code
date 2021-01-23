    public class Foo
    {
        public static Foo GetInstance(int parameter)
        {
            if (IsInCache(parameter))
            {
                // return from cache
            }
            else
            {
                Foo instance = new Foo(parameter);
                // add to cache
                return instance;
            }
        }
        private static bool IsInCache(int parameter)
        {
            //implement
        }
        private Foo(int parameter)
        {
        }
    }
