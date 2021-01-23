    builder.Register(c => 
    {
        if(true) 
        {
            return c.ResolveNamed<IProvider>("one");
        }
        else 
        {
            return c.ResolveNamed<IProvider>("two");
        }
    })
    .As<IProvider>()
    .InstancePerRequest();
