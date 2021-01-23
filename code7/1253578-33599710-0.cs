     var types= typeof(SomeClassInTheAssembly).Assembly;
            kernel.Bind(syntax => syntax.From(types)
                .SelectAllClasses()
                .BindDefaultInterface()
                .Configure(config => config.InRequestScope()));
