    Scan(
       scan =>
          {
             scan.TheCallingAssembly();
             scan.WithDefaultConventions();
             // Add the assembly that contains a certain type
             scan.AssemblyContainingType<IProductService>();
             scan.With(new ControllerConvention());
          }
        );
                   
