    public class Builder<T, TBuilder>
        where T: new()
        where TBuilder : Builder<T, TBuilder>, new()
    {
        protected T model;
        protected Builder()
        {
            model = new T();
        }
        public static TBuilder New()
        {
            return new TBuilder();
        }
        public T Get()
        {
            return model;
        }
    }
