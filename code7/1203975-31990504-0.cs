    var methodNode = (MethodDeclarationSyntax)node;
    string modelClassName = string.Empty;
    
    foreach (var param in methodNode.ParameterList.Parameters)
    {
    	var metaDataName = document.GetSemanticModelAsync().Result.GetDeclaredSymbol(param).ToDisplayString();
    //'document' is the current 'Microsoft.CodeAnalysis.Document' object
		var members = document.Project.GetCompilationAsync().Result.GetTypeByMetadataName(metaDataName).GetMembers();
		var props = (members.OfType<IPropertySymbol>());
		//now 'props' contains the list of properties from my type, 'Type1'
		foreach (var prop in props)
		{
			//some logic to do something on each proerty
		}
    	
    }
