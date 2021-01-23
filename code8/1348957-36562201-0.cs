		public async static Task TestingRenamer()
		{
			var code = @"
			using System;
			//We do not want to rename MyClass (we want to keep it the same)
			public class MyClass
			{
				public MyClass()
				{
				}
			}
			public class Program
			{
				public static void Main()
				{
					//We want to rename this usage
					var x = new MyClass();  
				}   
			}";
			var newClassName = "MY_NEW_CLASS_NAME";
			var document = getDocumentForCode(code);
			var compilation = await document.Project.GetCompilationAsync();
			var root = await document.GetSyntaxRootAsync();
			var originalClass = root.DescendantNodesAndSelf().OfType<ClassDeclarationSyntax>().First();
			var model = compilation.GetSemanticModel(root.SyntaxTree);
			var originalSymbol = model.GetDeclaredSymbol(originalClass);
			
			//Rename all 
			var newSolution = await Renamer.RenameSymbolAsync(document.Project.Solution, originalSymbol, newClassName, document.Project.Solution.Workspace.Options);
			//Revert the original class
			var newDocument = newSolution.GetDocument(document.Id);
			var newSyntaxRoot = await newDocument.GetSyntaxRootAsync();
			var newClass = newSyntaxRoot.DescendantNodes().OfType<ClassDeclarationSyntax>().Where(n => n.Identifier.ToString() == newClassName).Single();
			newSyntaxRoot = newSyntaxRoot.ReplaceNode(newClass, originalClass);
			newDocument = newDocument.WithSyntaxRoot(newSyntaxRoot);
			//We've now renamed all usages and reverted the class back to its original self.
			var finalSolution = newDocument.Project.Solution;
		}
		//Helper method to build Document
		private static Document getDocumentForCode(string code)
		{
			var ws = new AdhocWorkspace();
			var Mscorlib = MetadataReference.CreateFromAssembly(typeof(object).Assembly);
			var references = new List<MetadataReference>() { Mscorlib };
			var projInfo = ProjectInfo.Create(ProjectId.CreateNewId(), VersionStamp.Default, "MyProject", "MyAssembly", "C#", metadataReferences: references);
			var project = ws.AddProject(projInfo);
			var text = SourceText.From(code);
			var myDocument = ws.AddDocument(project.Id, "MyDocument.cs", text);
			return myDocument;
		}
