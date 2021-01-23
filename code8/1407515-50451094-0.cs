    builder.Register(c =>
      {
          var bar= c.Resolve<IBar>();
          var foo = new Foo(bar);
          return foo.ComputeAsync().ConfigureAwait(false).GetAwaiter().GetResult();
      })
    .As<IFoo>()
    .SingleInstance();
