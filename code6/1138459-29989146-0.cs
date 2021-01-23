    var container = new UnityContainer();
    
    container.AddNewExtension<Interception>();
    container.RegisterTypes(
        AllClasses.FromLoadedAssemblies().Where(
          t => t.Namespace == "Foo.Bar"),
        WithMappings.MatchingInterface,
        WithName.Default);
