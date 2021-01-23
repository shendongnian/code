    public class WindowsRuntimeResourceManager : ResourceManager
    {
    
      private readonly ResourceLoader resourceLoader;
    
      private WindowsRuntimeResourceManager(string baseName, Assembly assembly) : base(baseName, assembly)
      {
        this.resourceLoader = ResourceLoader.GetForViewIndependentUse(baseName);
      }
    
      public static void InjectIntoResxGeneratedApplicationResourcesClass(Type resxGeneratedApplicationResourcesClass)
      {
        resxGeneratedApplicationResourcesClass.GetRuntimeFields()
          .First(m => m.Name == "resourceMan")
          .SetValue(null, new WindowsRuntimeResourceManager(resxGeneratedApplicationResourcesClass.FullName, resxGeneratedApplicationResourcesClass.GetTypeInfo().Assembly));
      }
    
      public override string GetString(string name, CultureInfo culture)
      {
        return this.resourceLoader.GetString(name);
      }
    }
