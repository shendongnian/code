    public static class ContextSingleton
    {
        private static readonly Lazy<BillLines> _instance =
            new Lazy<BillLines>(() => new BillLines());
    
        public static BillLines Instance { get { return _instance.Value; } }
    
        private ContextSingleton()
        {
        }
    }
