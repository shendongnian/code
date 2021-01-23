       private static IKernel CreateKernel()
            {
                var kernel = new StandardKernel();
                try
                {
                    kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                    kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
    
                    RegisterServices(kernel);
                    GlobalConfiguration.Configuration.DependencyResolver =
           new NinjectResolver(kernel);
                    return kernel;
                }
                catch
                {
                    kernel.Dispose();
                    throw;
                }
            }
