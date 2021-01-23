    public sealed class NullChecker
    {
        public static NullChecker Instance { get; } = new NullChecker();
        private NullChecker() {}
        public static NullChecker Scrub<T>(T value, string paramName) where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName);
            }
            return this;
        }
    }
