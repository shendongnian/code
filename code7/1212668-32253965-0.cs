    .
    .
    .
    // elsewhere at app startup time attach the handler to the AppDomain.AssemblyResolve event
    AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
    .
    .
    .
    private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
        AssemblyName assemblyName = new AssemblyName(args.Name);
    
        // this.ReadOnlyPaths is a List<string> of paths to search.
        foreach (string path in this.ReadOnlyPaths)
        {
            // If specified assembly is located in the path, use it.
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            foreach (FileInfo fileInfo in directoryInfo.GetFiles())
            {
                 string fileNameWithoutExt = fileInfo.Name.Replace(fileInfo.Extension, "");                    
    
                 if (assemblyName.Name.ToUpperInvariant() == fileNameWithoutExt.ToUpperInvariant())
                 {
                      return Assembly.Load(AssemblyName.GetAssemblyName(fileInfo.FullName));
                 }
            }
        }
        return null;
    }
