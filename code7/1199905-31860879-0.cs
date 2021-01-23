    public static IEnumerable<string> GetMethodNames(string fileName)
    {
        var tree = Microsoft.CodeAnalysis.CSharp.CSharpSyntaxTree.ParseText(File.ReadAllText(fileName));
        var methods = tree.GetRoot().DescendantNodes().OfType<MethodDeclarationSyntax>().ToList();
        foreach (var method in methods)
        {
            yield return method.Identifier.Value.ToString();
        }
    }
