    class IDCollection
    {
        public IDCollection Cast<TResult>()
        {
            return this;
        }
        public IDCollection Where(Func<KeyValuePair<string, int>, bool> selector)
        {
            return this;
        }
        public IDCollection Select<TResult>(Func<KeyValuePair<string, int>, TResult> selector)
        {
            return this;
        }
    }
