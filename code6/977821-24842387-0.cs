    public static class NinjectWebCommon 
    {
        ...
        private static IKernel CreateKernel()
        {
           ...
        }
    
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUserService>().To<UserService>().InRequestScope();
        }        
    }
