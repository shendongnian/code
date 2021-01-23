	if (!this.Kernel.GetBindings(typeof(Func<IContext, IResolutionRoot>)).Any())
	{
		this.Bind<Func<IContext, IResolutionRoot>>().ToMethod(ctx => context => context.Kernel);
	}
	this.Bind<FuncProvider>().ToSelf().InSingletonScope();
	this.Bind<IFunctionFactory>().To<FunctionFactory>();
	this.Bind<IInstanceProvider>().To<StandardInstanceProvider>();
    #if !SILVERLIGHT_20 && !WINDOWS_PHONE && !NETCF_35
	this.Bind<IInterceptor>().To<FactoryInterceptor>()
		.When(request => typeof(IFactoryProxy).IsAssignableFrom(request.Target.Member.ReflectedType));
    #endif
