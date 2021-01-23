    AppDomain currentDomain = AppDomain.CurrentDomain;
    currentDomain.AssemblyResolve += new ResolveEventHandler(currentDomain_AssemblyResolve);
    
    Assembly currentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string defaultFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    
            string assemblyName = new AssemblyName(args.Name).Name;
    
            string assemblyNameDll = assemblyName + ".dll";
            string assemblyNameExe = assemblyName + ".exe";
    
            string assemblyPathDll = Path.Combine(defaultFolder, assemblyNameDll);
            string assemblyPathExe = Path.Combine(defaultFolder, assemblyNameExe);
    
            string assemblyPathToUse = null;
            if (File.Exists(assemblyPathDll))
            {
                assemblyPathToUse = assemblyPathExe;
            }
            else if (File.Exists(assemblyPathExe))
            {
                assemblyPathToUse = assemblyPathExe;
            }
            else
            {
                IEnumerable<string> merge = AssemblyFolders.Values;
                if (!string.IsNullOrEmpty(TempLoadingFolder))
                {
                    merge = AssemblyFolders.Values.Union(new List<string>() { TempLoadingFolder });
                }
                foreach (var folder in merge)
                {
                    assemblyPathDll = Path.Combine(folder, assemblyNameDll);
                    assemblyPathExe = Path.Combine(folder, assemblyNameExe);
    
                    if (File.Exists(assemblyPathDll))
                    {
                        assemblyPathToUse = assemblyPathDll;
                        break;
                    }
                    else if (File.Exists(assemblyPathExe))
                    {
                        assemblyPathToUse = assemblyPathExe;
                        break;
                    }
                }
            }
                 
            Assembly assembly = null;
    
            if (assemblyPathToUse != null && File.Exists(assemblyPathToUse))
            {
                assembly = Assembly.LoadFrom(assemblyPathToUse);
            }
            return assembly;
        }
