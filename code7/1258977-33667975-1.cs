    void Main(){
    	UpdateDll();
    	UpdateExe();
    }
    static void UpdateExe(){
    	var exe = @"C:\temp\sample.exe";
    	AssemblyDefinition ass = AssemblyDefinition.ReadAssembly(exe);
    	var module = ass.Modules.First();
    	var modAssVersion = module.AssemblyReferences.First(ar => ar.Name == "ClassLibrary1");
    	module.AssemblyReferences.Remove(modAssVersion);
    	modAssVersion.Version = new Version(4,0,3,0);
    	module.AssemblyReferences.Add(modAssVersion);
    	ass.Write(exe);
    }
    static void UpdateDll()
    {
    	String assemblyFile = @"C:\temp\assemblyName.dll";
    	AssemblyDefinition modifiedAss = AssemblyDefinition.ReadAssembly(assemblyFile);
    
    	var fileVersionAttrib = modifiedAss.CustomAttributes.First(ca => ca.AttributeType.Name == "AssemblyFileVersionAttribute");
    	var constArg = fileVersionAttrib.ConstructorArguments.First();
    	constArg.Value.Dump();
    	fileVersionAttrib.ConstructorArguments.RemoveAt(0);
    	fileVersionAttrib.ConstructorArguments.Add(new CustomAttributeArgument(modifiedAss.MainModule.Import(typeof(String)), "4.0.3.0"));
    	
    	modifiedAss.Name.Version = new Version(4,0,3,0);
    	modifiedAss.Write(assemblyFile);
    }
