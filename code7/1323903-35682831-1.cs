      .
      .
      builder.RegisterType<DiscussionHub>().ExternallyOwned();
      var container = builder.Build();
      GlobalHost.DependencyResolver = new   Autofac.Integration.SignalR.AutofacDependencyResolver(container);
      .
      .
