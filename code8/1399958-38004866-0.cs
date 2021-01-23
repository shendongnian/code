	var code = @"public partial class Abc { public string AAA { get; set; } }";
	var syntaxTree = CSharpSyntaxTree.ParseText(code);
	var syntax = (CompilationUnitSyntax)syntaxTree.GetRoot();
	var @class = syntax.ChildNodes().OfType<ClassDeclarationSyntax>().First();
	var properties = @class.ChildNodes().OfType<PropertyDeclarationSyntax>();
	foreach (var property in properties)
	{
		...
	}
