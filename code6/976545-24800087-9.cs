    public class Global : NinjectHttpApplication
        protected override IKernel CreateKernel()
        {
            IKernel kernel = new StandardKernel(new YourModule());
            return kernel;
        }
    public class YourModule: Ninject.Modules.NinjectModule
        {
    
            public override void Load()
            {
                Bind<IPostRepository>().To<PostRepository>();
            }  
        }
