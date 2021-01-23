    private GetResourceDictionary()
    {
        string address = @"WpfCustomControlLibrary1.dll";
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
        Application.Current.Resources.MergedDictionaries.Add(rd);
        Style style = Application.Current.Resources.MergedDictionaries[0]["myStyle"] as Style;
        button.Style = style;
    }
