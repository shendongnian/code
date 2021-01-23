    protected void Application_Start(object sender, EventArgs e) {       
        var container = new Container();  
    #if DEBUG
       container.Register<ICommuniucationService, FakeCommuniucationService>(Lifestyle.Singleton); 
    #else
       container.Register<ICommuniucationService, CommuniucationService>(Lifestyle.Singleton); 
    #endif         
                     
        container.Verify();
        DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
    }
