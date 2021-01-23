    public static IKernel ConfigureKernel(IKernel kernel)
    {
          kernel.Load(Assembly.Load("NZBDash.DependencyResolver.Modules"));
          return kernel;
    }
