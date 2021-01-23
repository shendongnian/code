    public class ServiceContainer : IServiceContainer
    {
      // internally manages ninjects kernel via methods such as...
      public void RegisterType<TService, TInstance>();
      public void RegisterTypes(Assembly assembly);
    
      // ultimately, this just segregates Ninject from your app so there are no Ninject dependencies
    }
