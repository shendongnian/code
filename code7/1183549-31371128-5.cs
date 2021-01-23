    builder
      .Register<MyObjectType>()
      .OnActivating(e => {
          var dep = e.Context.Resolve<TheDependency>();
          e.Instance.SetTheDependency(dep);
      });
