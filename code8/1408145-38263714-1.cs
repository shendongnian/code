    container
        .RegisterType<IDialogService>(new InjectionFactory(c => 
        { 
            var arg1 = c.Resolve<IArg1>();
            var arg2 = c.Resolve<IArg2>();
            var arg3 = c.Resolve<IArg3>();
            ServiceContainer serviceContainer = new ServiceContainer(arg1, arg2, arg3);
            serviceContainer.GetService<IDialogService>()
        }));
