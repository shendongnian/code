    using (var c = new UnityContainer())
    {
    	c.RegisterType(typeof(List<string>), new InjectionConstructor());
    	c.RegisterType<IMyParamClass, MyParamClass>();
    
    	c.RegisterType<IMyClass, MyClass>(
    					new PerThreadLifetimeManager(),
    					new InjectionConstructor(typeof(IMyParamClass),
    					new ResolvedParameter(typeof(List<string>))));
    
    	var obj = c.Resolve<IMyClass>();
    	obj.write();
    }
