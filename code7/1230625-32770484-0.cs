    var syntaxTree = CSharpSyntaxTree.ParseText(source);
    CSharpCompilation compilation = CSharpCompilation.Create(
        "assemblyName",
        new[] { syntaxTree },
        new[] { MetadataReference.CreateFromFile(typeof(object).Assembly.Location) },
        new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
   
    using (var dllStream = new MemoryStream())
    using (var pdbStream = new MemoryStream())
    {
        var emitResult = compilation.Emit(dllStream, pdbStream);
        if (!emitResult.Success)
        {
            // emitResult.Diagnostics
        }
    }
