    // 1. get source
    var methodRef = method.DeclaringSyntaxReferences.Single();
    var methodSource =  methodRef.SyntaxTree.GetText().GetSubText(methodRef.Span).ToString();
    // 2. compile in-memory as script
    var compilation = CSharpCompilation.CreateScriptCompilation("Temp")
        .AddReferences(initial.References)
        .AddSyntaxTrees(SyntaxFactory.ParseSyntaxTree(methodSource, CSharpParseOptions.Default.WithKind(SourceCodeKind.Script)));
    
    using (var dll = new MemoryStream())
    using (var pdb = new MemoryStream())
    {
        compilation.Emit(dll, pdb);
        // 3. load compiled assembly
        var assembly = Assembly.Load(dll.ToArray(), pdb.ToArray());
        var methodBase = assembly.GetType("Script").GetMethod(method.Name, new Type[0]);
        // 4. get il or even execute
        var il = methodBase.GetMethodBody();
        methodBase.Invoke(null, null);
    }
