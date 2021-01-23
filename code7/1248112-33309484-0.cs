    class Program
        {
            static void Main()
            {
                var syntaxTree = SyntaxTree.ParseCompilationUnit(
    @"using System;
    using System.Resources;
    namespace ResSample
    {
        class Program
        {
            static void Main()
            { 
                 ResourceManager resMan = new ResourceManager(""ResSample.Res1"", typeof(Program).Assembly);
                 Console.WriteLine(resMan.GetString(""String1""));
            }
        }
    }");
                var comp = Compilation.Create("ResTest.exe")
                                      .AddReferences(new AssemblyNameReference("mscorlib"))
                                      .AddSyntaxTrees(syntaxTree);
                var resourcePath = "ResSample.Res1.resources"; //Provide full path to resource file here
                var resourceDescription = new ResourceDescription(
                    resourceName: "ResSample.Res1.resources",
                    dataProvider: () => File.OpenRead(resourcePath),
                    isPublic: false);
                var emitResult = comp.Emit(
                    executableStream: File.Create("ResTest.exe"),
                    manifestResources: new[] { resourceDescription });
                Debug.Assert(emitResult.Success);
            }
