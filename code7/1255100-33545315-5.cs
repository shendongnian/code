    class IThingFactory
    {
        private IDictionary<Type, Func<IThing>> factories = new Dictionary<Type, Func<IThing>>();
        public void Register(Type t, Func<IThing> factory);
        {
             if(!typeof(IThing).IsAssignableFrom(t))
                 throw new ArgumentException("This is not a thing");
             this.factories.Add(t, factory);
        }
        public void Register<T>() where T : IThing, new()
        {
            this.Register<T>(() => new T());
        }
        public void Register<T>(Func<IThing> factory) where T : IThing
        {
            this.Register(typeof(T), factory);
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
         factory.Register<B>();
         factory.Register<C>(() => new C("Test"));
         var instance = factory.MakeThing(typeof(A));
    }
