        IContainer container = builder.Build(ContainerBuildOptions.ExcludeDefaultModules);
    This will remove all default modules, ie : 
        private void RegisterDefaultAdapters(IComponentRegistry componentRegistry)
        {
          this.RegisterGeneric(typeof(KeyedServiceIndex<, >)).As(new Type[]
          {
            typeof(IIndex<, >)
          }).InstancePerLifetimeScope();
          componentRegistry.AddRegistrationSource(new CollectionRegistrationSource());
          componentRegistry.AddRegistrationSource(new OwnedInstanceRegistrationSource());
          componentRegistry.AddRegistrationSource(new MetaRegistrationSource());
          componentRegistry.AddRegistrationSource(new LazyRegistrationSource());
          componentRegistry.AddRegistrationSource(new LazyWithMetadataRegistrationSource());
          componentRegistry.AddRegistrationSource(new StronglyTypedMetaRegistrationSource());
          componentRegistry.AddRegistrationSource(new GeneratedFactoryRegistrationSource());
        }
