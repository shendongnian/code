	String assemblyFile = @"c:\assemblyName.dll";
	AssemblyDefinition modifiedAss = AssemblyDefinition.ReadAssembly(assemblyFile);
	var fileVersionAttrib = modifiedAss.CustomAttributes.First(ca => ca.AttributeType.Name == "AssemblyFileVersionAttribute");
	var constArg = fileVersionAttrib.ConstructorArguments.First();
	constArg.Value.Dump();
	fileVersionAttrib.ConstructorArguments.RemoveAt(0);
	fileVersionAttrib.ConstructorArguments.Add(new CustomAttributeArgument(modifiedAss.MainModule.Import(typeof(String)), "4.0.3.0"));
	
	modifiedAss.Name.Version = new Version(4,0,3,0);
	modifiedAss.Write(assemblyFile);
