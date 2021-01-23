        private static void RegisterServices(IKernel kernel)
        {
            var modules = new List<INinjectModule>
            {
                new ServiceModule(),
                new RepositoryModule()
            };
        
            kernel.Load(modules);
        }  
 
