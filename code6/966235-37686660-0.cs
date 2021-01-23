       protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterType<IShellViewModel, ShellViewModel>();
            Container.RegisterType<MyService>(new ContainerControlledLifetimeManager());
            Container.RegisterInstance<MyService>(new MyService());
            Application.Current.Resources.Add("IoC", this.Container);
        }
