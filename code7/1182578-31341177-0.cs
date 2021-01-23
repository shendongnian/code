    var tree = CSharpSyntaxTree.ParseText("public class NestedDict<T>: Dictionary<string, Dictionary<string, T> { } ");
    var cu = (CompilationUnitSyntax)tree.GetRoot();
    var c = (ClassDeclarationSyntax)cu.ChildNodes().Single();
    
    var baseDeclaration = (BaseTypeSyntax)c.BaseList.ChildNodes().Single();
    var baseNameSyntax = (GenericNameSyntax)baseDeclaration.Type;
    Console.WriteLine(baseNameSyntax.TypeArgumentList.Arguments[0].ToFullString());
    Console.WriteLine(baseNameSyntax.TypeArgumentList.Arguments[1].ToFullString());
