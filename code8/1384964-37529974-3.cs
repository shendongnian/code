     // Register decorators first
     container.RegisterConditional<IDependency, DependencyDecorator1>(
         c => c.Consumer.ImplementationType == typeof(Service1));
     container.RegisterConditional<IDependency, DependencyDecorator2>(
         c => c.Consumer.ImplementationType == typeof(Service2));
     // Register the real implementation last using !c.Handled
     container.RegisterConditional<IDependency, RealImplementationDependency>(
         c => !c.Handled);
