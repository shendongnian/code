    // In the analyzer
    MethodDeclarationSyntax someMethodSyntax = ...
    var container = new SyntaxElementContainer<string>
    {
        {"TargetMethodKey", someMethodSyntax}
    };
    // In the code fixer
	var bagInterpreter = new PropertyBagSyntaxInterpreter<string>(diagnostic, root);
	var myMethod = bagInterpreter.GetNodeAs<MethodDeclarationSyntax>("TargetMethodKey");
