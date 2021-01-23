	var mscorlib = PortableExecutableReference.CreateFromAssembly(typeof(object).Assembly);
	var ws = new AdhocWorkspace();
    //Create new solution
	var solId = SolutionId.CreateNewId();
	var solutionInfo = SolutionInfo.Create(solId, VersionStamp.Create());
    //Create new project
	var project = ws.AddProject("Sample", "C#");
	project = project.AddMetadataReference(mscorlib);
    //Add project to workspace
	ws.TryApplyChanges(project.Solution);
	string text = @"
	class C
	{
		void M()
		{
			M();
			M();
		}
	}";
	var sourceText = SourceText.From(text);
    //Create new document
	var doc = ws.AddDocument(project.Id, "NewDoc", sourceText);
    //Get the semantic model
	var model = doc.GetSemanticModelAsync().Result;
    //Get the syntax node for the first invocation to M()
	var methodInvocation = doc.GetSyntaxRootAsync().Result.DescendantNodes().OfType<InvocationExpressionSyntax>().First();
	var methodSymbol = model.GetSymbolInfo(methodInvocation).Symbol;
    //Finds all references to M()
	var referencesToM = SymbolFinder.FindReferencesAsync(methodSymbol,  doc.Project.Solution).Result;
