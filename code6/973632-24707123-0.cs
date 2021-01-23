    private ISomeInterface aDependency;
    
    public ISomeInterface MyDependency
    {
        get 
        { 
            if (aDependency == null)
                aDependecy = new SomeConcreteClass();
            return aDependency;
        }
        set { aDependency = value; }
    }
