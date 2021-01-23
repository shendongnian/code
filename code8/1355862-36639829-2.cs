    string address = @"WpfCustomControlLibrary.dll";
    List<Stream> bamlStreams = new List<Stream>();
    Assembly skinAssembly = Assembly.LoadFrom(address);            
    string[] resourceDictionaries = skinAssembly.GetManifestResourceNames();
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
                //Here you can see all your ResourceDictionaries
                //entry is your ResourceDictionary from assembly
              }
          }
        }
    }
     
