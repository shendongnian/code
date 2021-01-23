    container.Register(Classes.FromThisAssembly()
      .BasedOn(typeof(IService))
      .WithServiceSelf()
      .WithServiceBase()
      .Where(type => !(type is IDep3))
      .LifestyleTransient());
