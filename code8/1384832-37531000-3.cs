    var compilation = CSharpCompilation.Create("a")
        .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
        .AddReferences(
            MetadataReference.CreateFromFile(typeof(object).GetTypeInfo().Assembly.Location))
        .AddSyntaxTrees(CSharpSyntaxTree.ParseText(
            @"
    using System;
    public static class C
    {
        public static void M()
        {
            Console.WriteLine(""Hello Roslyn."");
        }
    }"));
    var fileName = "a.dll";
    compilation.Emit(fileName);
    var a = AssemblyLoadContext.Default.LoadFromAssemblyPath(Path.GetFullPath(fileName));
    a.GetType("C").GetMethod("M").Invoke(null, null);
