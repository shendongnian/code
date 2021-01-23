    public static class ReadOnlyCollection
    {
        public static IReadOnlyCollection<TResult> Empty<TResult>()
        {
            return EmptyReadOnlyCollection<TResult>.Instance;
        }
        private static class EmptyReadOnlyCollection<TElement>
        {
            static volatile TElement[] _instance;
            public static IReadOnlyCollection<TElement> Instance
            {
                get { return _instance ?? (_instance = new TElement[0]); }
            }
        }
    }
