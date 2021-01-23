    private GetResourceDictionary()
    {
        string address = @"WpfCustomControlLibrary1.dll";
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
                    bamlStreams.Add(entry.Value as Stream);
                 }
              }
            }
         }
         IList<ResourceDictionary> listResDict = new List<ResourceDictionary>();
         foreach (var item in bamlStreams)
         {
             listResDict.Add(LoadBaml<ResourceDictionary>(item));
         }
    }
    static T LoadBaml<T>(Stream stream) 
    {
       var reader = new Baml2006Reader(stream);
       var writer = new XamlObjectWriter(reader.SchemaContext);
       while (reader.Read())
         writer.WriteNode(reader);
       return (T)writer.Result;
    } 
