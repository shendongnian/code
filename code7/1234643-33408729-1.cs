    protected override void ConfigureApplicationContainer(TinyIoCContainer container)
    {
        base.ConfigureApplicationContainer(container);
        container.Register<JsonSerializer,CustomJsonSerializer>).AsSingleton();            
    }
