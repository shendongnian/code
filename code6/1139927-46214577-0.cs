    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
           
            return container;
         }
   
     private static IUnityContainer BuildUnityContainer()
     {
        var container = new UnityContainer();       
        GlobalConfiguration.Configuration.UseUnityActivator(container);
        RegisterTypes(container);
        return container;
     }
