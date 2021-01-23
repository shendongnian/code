    var tmp = code.Types.Cast<CodeTypeDeclaration>().ToArray();		// temp. copy of our types-list to avoid ModifiedException during iteration
	foreach (var type in tmp)
	{
		var attributes = type.CustomAttributes.Cast<CodeAttributeDeclaration>().Where(x => x.Name.StartsWith("System.Xml.Serialization"));
		var namespaceAttribute = attributes.SelectMany(x => x.Arguments.Cast<CodeAttributeArgument>()).FirstOrDefault(x => x.Name == "Namespace");
		string xsdNamespace = ((CodePrimitiveExpression)namespaceAttribute.Value).Value as string;
		if (xsdNamespace != schema.TargetNamespace)
		{
			Console.WriteLine("INFO: Found referenced type {0} which is not declared in current schema", type.Name);
			// omit the type from the current namespace and add a using-directive to the generated source-file if not yet done
			code.Types.Remove(type);
			var nameWithinAssembly = this.m_typeMapper.GetDotNetNamespaceFromXsdNamespace(xsdNamespace);
			// add a using-directive for the type if not already done
			if (!(code.Imports.Cast<CodeNamespaceImport>().Any(x => x.Namespace == nameWithinAssembly))) code.Imports.Add(new CodeNamespaceImport(nameWithinAssembly));
		}
	}
