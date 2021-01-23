    public abstract class SingletonBase<S, T> where S : class, new()
    {
        protected static readonly Dictionary<string, List<T>> Dictionary = new Dictionary<string, List<T>>();
        private static readonly S _instance = new S();
        private static readonly object _lock = new object();
        public static S Instance
        {
            get
            {
                lock (_lock)
                {
                    return _instance;
                }
            }
        }
        public IEnumerable<T> For(string systemLangCode)
        {
            systemLangCode = systemLangCode.ToLower();
            if (!Dictionary.ContainsKey(systemLangCode))
            {
                PopulateDictionary(systemLangCode);
            }
            return Dictionary.FirstOrDefault(d => d.Key == systemLangCode).Value;
        }
        protected abstract void PopulateDictionary(string systemLangCode);
    }
