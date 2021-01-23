    public static class NinjectWebCommon
    {
         public static readonly Bootstrapper bootstrapper = new Bootstrapper();
         
         // ...
         private static void RegisterServices(IKernel kernel)
         {
             kernel.Bind<ServiceHost>().To<NinjectServiceHost>();
             // ...
          }
     }
