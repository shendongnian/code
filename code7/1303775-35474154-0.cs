    public static class CompositionUtil
    {
        private static readonly Lazy<CompositionContainer> _container = new Lazy(InitContainer);
        private static CompositionContainer InitContainer()
        {
            DirectoryCatalog catalog = new DirectoryCatalog(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin"), "*.dll");
            return new CompositionContainer(catalog);
        }
        public static CompositionContainer Container
        {
            get { return _container.Value; }
        }
    }
