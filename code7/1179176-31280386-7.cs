    builder.RegisterGeneric(typeof(LifetimeScopeHandler<,>))
           .WithParameter((pi, c) => pi.Name == "decoratedHandler",
                          (pi, c) =>
                          {
                              ILifetimeScope scope = c.Resolve<ILifetimeScope>();
                              ILifetimeScope piplineScope = scope.BeginLifetimeScope("pipline");
                              var o = piplineScope.ResolveKeyed("FirstDecoratorHandler", pi.ParameterType);
                              scope.Disposer.AddInstanceForDisposal(piplineScope);
                              return o;
                          })
           .As(typeof(IHandle<,>));
