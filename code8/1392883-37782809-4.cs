    SyntaxTree tree = CSharpSyntaxTree.ParseText(
        @"using System;
        using System.Collections;
        using System.Linq;
        using System.Text;
        namespace HelloWorld
        {
            class Program
            {
                static void Main(string i)
                {
                    var j = ""1"";
                    var k = i + j;
                }
            }
        }");
    var root = (CompilationUnitSyntax)tree.GetRoot();
    var ns = root.Members[0] as NamespaceDeclarationSyntax;
    var cls = ns.Members[0] as ClassDeclarationSyntax;
    var method = cls.Members[0] as MethodDeclarationSyntax;
    var statement = method.Body.Statements[1] as LocalDeclarationStatementSyntax;
    var variable = statement.Declaration.Variables[0];
    var binary = variable.Initializer.Value as BinaryExpressionSyntax;
    var vari = binary.Left as IdentifierNameSyntax;
    var varj = binary.Right as IdentifierNameSyntax;
    Console.WriteLine(IsParameter(vari));   //True
    Console.WriteLine(IsParameter(varj));  //False
