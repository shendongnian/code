    public static class ExtensionMethods
    {
        public static Converter<TFrom> Convert<TFrom>(this IFetcher<TFrom> fetcher)
        {
            return new Converter<TFrom>(fetcher);
        }
        public class Converter<TFrom>
        {
            private readonly IFetcher<TFrom> _fetcher;
            public Converter(IFetcher<TFrom> fetcher)
            {
                _fetcher = fetcher;
            }
            public IFetcher<TTo> To<TTo>()
            {
                return new Adaptor<TFrom, TTo>(_fetcher);
            }
        }
    }
