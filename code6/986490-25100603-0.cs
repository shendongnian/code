    public A getObject<T>() where T : new, IAFactory
    {
        return getObject(new T()
    }
    public A getObject<T>(T factory) where T : IAFactory
    {
        return factory.Build();
    } 
