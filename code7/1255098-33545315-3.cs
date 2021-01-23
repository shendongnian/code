    class IThingFactory
    {
        private IDictionary<Type, Func<IThing>> factories = new Dictionary<Type, Func<IThing>>();
        public void Register(Type t, Func<IThing> factory);
        {
             if(!typeof(IThing).IsAssignableFrom(t))
                 throw not ArgumentException("This is not a thing");
             this.factories.Add(t, factory);
        }
        public IThing MakeThing(Type type);
        {
            if (!factories.ContainsKey(type))
                 throw new ArgumentException("I don't know this thing");
            return factories[type]();
        }
    }
    public void Main()
    {
         var factory = new IThingFactory();
         factory.Register(typeof(A), () => new A());
         var instance = factory.MakeThing(typeof(A));
    }
