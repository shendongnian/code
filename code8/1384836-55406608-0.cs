    var dotnetCoreDirectory = Path.GetDirectoryName(typeof(object).GetTypeInfo().Assembly.Location);
    var compilation = CSharpCompilation.Create("LibraryName")
        .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
        .AddReferences(
            MetadataReference.CreateFromFile(typeof(object).GetTypeInfo().Assembly.Location),
            MetadataReference.CreateFromFile(typeof(Console).GetTypeInfo().Assembly.Location),
            MetadataReference.CreateFromFile(Path.Combine(dotnetCoreDirectory, "System.Runtime.dll")))
        .AddSyntaxTrees(CSharpSyntaxTree.ParseText(
            @"public static class ClassName 
            { 
                public static void MethodName() => System.Console.WriteLine(""Hello C# Compilation."");
            }"));
    var fileName = "LibraryName.dll";
    // Debug output. In case your environment is different it may show some messages.
    foreach (var compilerMessage in compilation.GetDiagnostics())
        Console.WriteLine(compilerMessage);
    compilation.Emit(fileName);
    var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(Path.GetFullPath(fileName));
    assembly.GetType("ClassName").GetMethod("MethodName").Invoke(null, null);
