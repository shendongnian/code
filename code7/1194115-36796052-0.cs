    private static Lazy<T> Lazy<T>(Func<T> func) => new Lazy<T>(func);
    public static void RegisterDelayedFunc<T>(this Container container, Lifestyle lifestyle)
        where T : class
    {
        var lazy = Lazy(() => lifestyle.CreateProducer<T, T>(container));
        container.RegisterSingleton<Func<T>>(() => lazy.Value.GetInstance());
    }
	Container container = new Container();
	container.RegisterDelayedFunc<Derived1>(Lifestyle.Singleton);
	container.RegisterDelayedFunc<Derived2>(Lifestyle.Singleton);
	container.RegisterDelayedFunc<Derived3>(Lifestyle.Singleton);
	container.RegisterSingleton<MyFactory>();
