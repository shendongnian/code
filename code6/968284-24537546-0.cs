    using Ninject.Extensions.Conventions;
    
        public class RepositoryModule : NinjectModule
        {
            public override void Load()
            {
                IKernel ninjectKernel = this.Kernel;
    
                ninjectKernel.Scan(kernel =>
                {
                    kernel.FromAssemblyContaining<ProjectRepository>();                
                    kernel.BindWithDefaultConventions();
                    kernel.AutoLoadModules();
                    kernel.InRequestScope();                
    
                });
            
           }
        }
