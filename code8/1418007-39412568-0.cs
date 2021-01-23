    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
       public class InterceptModule : IConfigurableModule
       {
       public void ConfigureContainer(ServiceConfigurationContext context)
       {
           context.Services.Intercept<IContentRepositoryDescriptor>((locator, defaultService) =>
           {
               var pageRepositoryDescriptor = defaultService as PageRepositoryDescriptor;
               return pageRepositoryDescriptor != null ?
                   new MyPageRepositoryDescriptor(pageRepositoryDescriptor) :
                   defaultService;
           });
       }
 
       public void Initialize(InitializationEngine context)
       {}
 
       public void Uninitialize(InitializationEngine context)
       {}
    }
