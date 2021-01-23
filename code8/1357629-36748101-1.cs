    private GetResourceDictionary()
    {
        string address = @"WpfCustomControlLibrary1.dll";
        List<MemoryStream> bamlStreams = new List<MemoryStream>();
        Assembly skinAssembly = Assembly.LoadFrom(address);
        string[] resourceDictionaries = skinAssembly.GetManifestResourceNames();
        Stream bamlStream = null;            
        string name = "themes/AllStylesDictionary.baml";//themes/AllStylesDictionary.baml
        foreach (string resourceName in resourceDictionaries)
        {
           ManifestResourceInfo info = skinAssembly.GetManifestResourceInfo(resourceName);
           if (info.ResourceLocation != ResourceLocation.ContainedInAnotherAssembly)
           {
              Stream resourceStream = skinAssembly.GetManifestResourceStream(resourceName);
              using (ResourceReader reader = new ResourceReader(resourceStream))
              {
                  foreach (DictionaryEntry entry in reader)
                  {
                     if (entry.Key.ToString().Equals(name.ToLower()))
                     {
                         bamlStream = entry.Value as Stream;
                     }
                  }
              }
            }
        }   
        ResourceDictionary rd = LoadBaml<ResourceDictionary>(bamlStream);
    }
