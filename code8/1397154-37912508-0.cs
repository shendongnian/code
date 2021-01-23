    public sealed TheMethod()
    {
        // Do something that should always be done
        DoSomethingImportant()
    
        // Call the derived class implementation
        TheMethodCore();
    }
    
    protected abstract void TheMethodCore();
