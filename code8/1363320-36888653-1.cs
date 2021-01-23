    var container = new UnityContainer();
            container.RegisterType<IB, B>(new InjectionConstructor(1, "Test"));
            container.RegisterType<IA, A>(new InjectionConstructor(new ResolvedParameter<IB>(),"Test"));
            container.RegisterType<IC, C>();
            var c = container.Resolve<IC>();
