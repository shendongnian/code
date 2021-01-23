    void Main()
    {
    	var tree = CSharpSyntaxTree.ParseText(@"
    using X = System.Text;
    using Y = System;
    using System.IO;
    
    namespace ConsoleApplication1
    {
    }"
    );
    
    	var mscorlib = PortableExecutableReference.CreateFromFile(typeof(object).Assembly.Location);
    	var compilation = CSharpCompilation.Create("MyCompilation", syntaxTrees: new[] { tree }, references: new[] { mscorlib });
    	var semanticModel = compilation.GetSemanticModel(tree);
    	var root = tree.GetRoot();
    
    	// Get usings
    	foreach (var usingDirective in root.DescendantNodes().OfType<UsingDirectiveSyntax>())
    	{
    		var symbol = semanticModel.GetSymbolInfo(usingDirective.Name).Symbol;
    		var name = symbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
    		name.Dump();
    	}
    }
