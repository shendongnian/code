	// required 'using' directives: System.IO, System.Xml.Linq
	
	public static void EmbedResourceFiles(string projectFilename, IEnumerable<string> fileList, bool makeLinks = true)
	{
		// This is the namespace used by the .csproj Xml file
		XNamespace ns = "http://schemas.microsoft.com/developer/msbuild/2003";
		// 1: Open the document
		XDocument project = XDocument.Load(projectFilename);
		// 2: Locate target ItemGroup
		var itemGroup = project.Descendants(ns + "Compile").FirstOrDefault()?.Parent;
		if (itemGroup == null)
			throw new Exception("Failed to locate correct ItemGroup node in project file");
		// 3: Insert EmbedResource nodes
		foreach (var file in fileList)
		{
			var node = new XElement(ns + "EmbeddedResource", new XAttribute("Include", file));
			if (makeLinks)
				node.Add(new XElement(ns + "Link", Path.GetFileName(file)));
			itemGroup.Add(node);
		}
		// 4: Save it, keeping a backup just in case.
		File.Copy(projectFilename, projectFilename + ".bak", true);
		project.Save(projectFilename);
	}
