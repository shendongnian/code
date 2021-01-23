    class IDCollection
    {
    }
    static class IDCollectionExtensions
    {
        public static IDCollection Cast<TResult>(this IDCollection source)
        {
            return source;
        }
        public static IDCollection Where(this IDCollection source, Func<KeyValuePair<string, int>, bool> selector)
        {
            return source;
        }
        public static IDCollection Select<TResult>(this IDCollection source, Func<KeyValuePair<string, int>, TResult> selector)
        {
            return source;
        }
    }
