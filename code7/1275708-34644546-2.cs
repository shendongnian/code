    public MyObj
    {
       private IZipFileWrapper zipFileWrapper;
       public MyObj(IZipFileWrapper zipFileWrapper)
       {
          this.zipFileWrapper = zipFileWrapper;
       }
       public IEnumerable<ConfigurationViewModel> ExtractXmlFromZip(string fileName)
       {
           var configs = new List<ConfigurationViewModel>();
           // Call the wrapper
           using (var archive = this.zipFileWrapper.OpenRead(fileName))
           {
               foreach (ZipArchiveEntry entry in archive.Entries)
               {
                  if (entry.FullName.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                  {
                      LoadConfigfromZipArchiveEntry(entry, configs)
                  }
               }
           }
           return configs;
        }
    }
