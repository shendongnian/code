    IFoo foo;
    if (Container.IsRegistered<IFoo>(AliasString))
    {
        foo = container.Resolve<IFoo>(AliasString);
    }
    else
    {
        foo = container.Resolve<IFoo>();
    }
