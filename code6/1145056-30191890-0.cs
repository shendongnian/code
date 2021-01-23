    public void SetUpContainer(IWindsorContainer container)
	{
	    container.Register(Classes.FromAssemblyContaining<Foo>()
								  .BasedOn(typeof(IFoo<>))
								  .WithService.Base()
								  .Configure(r => r.Interceptors<FooInterceptor>()));
    }
