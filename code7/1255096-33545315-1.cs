    class IThingFactory
    {
        private IDictionary<Type, Func<IThing>> factories = new Dictionary<Type, Func<IThing>>();
        public void Register(Type t, Func<IThing> factory);
        {
             this.factories.Add(t, factory);
        }
        public IThing MakeThing(Type type);
        {
            if (!factories.ContainsKey(type))
                 throw new ArgumentException("Don't know what to do");
            return factories[type]();
        }
    }
    public void Main()
    {
         var factory = new IThingFactory();
         factory.Register(typeof(A), () => new A());
         var instance = factory.MakeThing(typeof(A));
    }
