    var tree = CSharpSyntaxTree.ParseText(@"
    class MyClass
    {
        void MyMethod()
        {
        }
    }");
    //We navigate these trees by getting the root, and then
    //searching up and down the tree for the nodes we're interested in.
    var root = tree.GetRoot();
    var method = root.DescendantNodes().OfType<MethodDeclarationSyntax>().Single();
    //Let's create a new method with a different name
    var newIdentifier = SyntaxFactory.Identifier("MyNewMethodWithADifferentName");
    //NOTE: We're creating a new tree, not changing the old one!
    var newMethod = method.WithIdentifier(newIdentifier);
    Console.WriteLine(newMethod);
    
