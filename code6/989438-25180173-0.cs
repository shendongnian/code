    static class Singletons
    {
        private static readonly Lazy<Factory1> factory1;
        private static readonly Lazy<Factory2> factory2;
        static Singletons()
        {
            factory1 = new Lazy<Factory1>(true); // or Lazy<Factory1>(() => /* */, true)
            factory2 = new Lazy<Factory2>(true); // or Lazy<Factory2>(() => /* */, true)
        }
        public Factory1 Factory1
        {
            get { return factory1.Value; }
        }
        public Factory2 Factory2
        {
            get { return factory2.Value; }
        }
        // etc
    }
