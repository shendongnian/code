	var tree = CSharpSyntaxTree.ParseText(@"
	using System;
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
			var x = new MyClass();  
		}   
	}");
	var mscorlib = MetadataReference.CreateFromFile(typeof(object).Assembly.Location);
	var compilation = CSharpCompilation.Create("MyCompilation",
		syntaxTrees: new[] { tree }, references: new[] { mscorlib });
	var model = compilation.GetSemanticModel(tree);
	var objectCreationSyntax = tree.GetRoot().DescendantNodes().OfType<ObjectCreationExpressionSyntax>().Single();
	var namedTypeSymbol = model.GetSymbolInfo(objectCreationSyntax).Symbol;
