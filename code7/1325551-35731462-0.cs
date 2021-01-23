    	protected void Application_Start()
        {
            Funq container = new Funq.Container();
            container.Register<IMyType>(c => new MyType());
            ControllerBuilder.Current.SetControllerFactory(new FunqControllerFactory(container));
        }
