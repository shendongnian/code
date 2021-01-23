    // default implementation can use Activator.CreateInstance that instantiate parameterless viewmodels
    // You'll override it to use IoC
    private Func<Type, object> resolver = null;
    public static void SetResolverFactory(Func<Type, object> factoryMethod) 
    {
        if(factoryMethod!=null) 
            throw new ArgumentNullException(nameof(factoryMethod));
        resolver = factoryMethod;
    }
    // inside your ViewModelLocator
    protected T Resolve<T>() 
    {
        return (T)resolver(typeof(T));
    }
