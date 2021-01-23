	var componentModel = (IComponentModel)Microsoft.VisualStudio.Shell.Package.GetGlobalService(typeof(SComponentModel));
	var workspace = componentModel.GetService<VisualStudioWorkspace>();
	var sourceText = SourceText.From("Test");
	var folders = new List<string>() { "GoHere" };
	var proj = workspace.CurrentSolution.Projects.Single();
	var document = proj.AddDocument("Test.cs", sourceText, folders);
	var result = workspace.TryApplyChanges(document.Project.Solution);
