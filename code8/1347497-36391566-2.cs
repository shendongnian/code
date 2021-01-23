    // MyPrject.Web.UI.csproj
    // This project requires an IPersonRepository
    namespace MyProject.Web.UI
    {
      // Asp.Net MVC Example
      internal class IoCConfig
      {
        public static void Start()
        {
          var builder = new ContainerBuilder();
          var assemblies = BuildManager.GetReferencedAssemblies()
            .Cast<Assembly>();
          builder.RegisterAssemblyModules(assemblies);
        }
      }
    }
    
