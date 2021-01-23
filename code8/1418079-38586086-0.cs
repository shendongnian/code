    public void Configuration(IAppBuilder app)
            {
                var container = new Container();
                
                container.Register<IEventDataController, EventDataController>(Lifestyle.Singleton);
    
                var activator = new SimpleInjectorHubActivator(container);
                GlobalHost.DependencyResolver.Register(typeof(IHubActivator), () => activator);
                
                app.MapSignalR();
            }
