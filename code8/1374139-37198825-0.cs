    public void MyAssemblyLoadEventHandler(object sender, AssemblyLoadEventArgs args)
    {
    	Console.WriteLine("ASSEMBLY LOADED: " + args.LoadedAssembly.FullName);
    	string loadedAssemblyFullName = args.LoadedAssembly.FullName;
    	foreach (System.Reflection.Assembly parent in AppDomain.CurrentDomain.GetAssemblies()) {
    		System.Reflection.AssemblyName[] referencedAssemblies = parent.GetReferencedAssemblies();
    		string[] referencedFullNames = (from r in referencedAssembliesr.FullName).ToArray;
    		if (referencedFullNames.Contains(loadedAssemblyFullName)) {
    			Console.Writeline(IO.Path.GetFileName(args.LoadedAssembly.CodeBase) + 
    			                  " was referenced by " + 
    			                  IO.Path.GetFileName(parent.CodeBase));
    		}
    	}
    }
