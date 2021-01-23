    public class AssemblyResolver : System.Web.Http.Dispatcher.DefaultAssembliesResolver
        {
            public override ICollection<Assembly> GetAssemblies()
            {
                ICollection<Assembly> baseAssemblies = base.GetAssemblies();
                List<Assembly> assemblies = new List<Assembly>(baseAssemblies);
    
                var externalAssembly = typeof(MyApp.External).Assembly;
                assemblies.Add(externalAssembly);
              
                return baseAssemblies;
            }
        }
