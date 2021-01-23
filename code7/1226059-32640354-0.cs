	AdhocWorkspace workspace = new AdhocWorkspace();
	Project project = workspace.AddProject("Test", LanguageNames.CSharp);
    
    //Attach a syntax annotation to the class declaration
	var syntaxAnnotation = new SyntaxAnnotation("ClassTracker");
	var classDeclaration = SyntaxFactory.ClassDeclaration("MyClass")
		.WithAdditionalAnnotations(syntaxAnnotation);
	var compilationUnit = SyntaxFactory.CompilationUnit().AddMembers(classDeclaration);
	Document document = project.AddDocument("Test.cs", compilationUnit);
	SemanticModel semanticModel = document.GetSemanticModelAsync().Result;
    //Use the annotation on our original node to find the new class declaration
	var changedClass = document.GetSyntaxRootAsync().Result.DescendantNodes().OfType<ClassDeclarationSyntax>()
		.Where(n => n.HasAnnotation(syntaxAnnotation)).Single();
	var symbol = semanticModel.GetDeclaredSymbol(changedClass);
