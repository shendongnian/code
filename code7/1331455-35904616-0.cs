    XNamespace msbuild = "http://schemas.microsoft.com/developer/msbuild/2003";
    XDocument projDefinition = XDocument.Load(@"C:\Path\To\Project.csproj");
    var propertyGroups = projDefinition.Element(msbuild + "Project")
		.Elements(msbuild + "PropertyGroup");
    string assemblyNameValue = "";
    foreach (XElement propertyGroup in propertyGroups)
    {
	    //Check if this <PropertyGroup> elements contains a <AssemblyName> element
        if (propertyGroup.Element(msbuild + "AssemblyName") != null)
	    {
		    assemblyNameValue = propertyGroup.Element(msbuild + "AssemblyName").Value;
		    break;
	    }
    }
    Console.WriteLine("AssemblyName: " + assemblyNameValue);
