    static string Code =
    @"namespace TestNamespace
    {
        public class Test
        {
            public int A { get; set; }
            public int B { get; set; }
    
            public Test(int a, int b)
            {
                A = a;
                B = b;
            }
        }
    }";
    
    static void Main(string[] args)
    {
        var syntaxTree = CSharpSyntaxTree.ParseText(Code);
        var syntaxTrees = new SyntaxTree[] { syntaxTree }; // Add SyntaxTree array from project files.
        var compilation = CSharpCompilation.Create("tempAssembly", syntaxTrees);
        var semanticModel = compilation.GetSemanticModel(syntaxTree);
        var caretPosition = 46;
        var symbol = SymbolFinder.FindSymbolAtPositionAsync(semanticModel, caretPosition, new AdhocWorkspace()).Result;
        var fullName = symbol.ToString(); // fullName is "TestNamespace.Test"
    }
