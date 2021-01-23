    public class MyAssembliesResolver : DefaultAssembliesResolver
    {
      public override ICollection<Assembly> GetAssemblies()
     {
        ICollection<Assembly> baseAssemblies = base.GetAssemblies();
        List<Assembly> assemblies = new List<Assembly>(baseAssemblies);
        var controllersAssembly = Assembly.Load("MyAssembly");
        baseAssemblies.Add(controllersAssembly);
        return assemblies;
      }
    }
