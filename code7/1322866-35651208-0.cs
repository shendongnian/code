    string code = new StreamReader(filePath).ReadToEnd();
    var syntaxTree = CSharpSyntaxTree.ParseText(code);
    var syntaxRoot = syntaxTree.GetRoot(); 
    
    IEnumerable<InterfaceDeclarationSyntax> interfaceDeclarations = syntaxRoot.DescendantNodes().OfType<InterfaceDeclarationSyntax>();
