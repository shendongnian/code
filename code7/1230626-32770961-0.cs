     class Program
        {
            private static readonly IEnumerable<string> DefaultNamespaces =
                new[]
                {
                    "System", 
                    "System.IO", 
                    "System.Net", 
                    "System.Linq", 
                    "System.Text", 
                    "System.Text.RegularExpressions", 
                    "System.Collections.Generic"
                };
    
            private static string runtimePath = @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5.1\{0}.dll";
    
            private static readonly IEnumerable<MetadataReference> DefaultReferences =
                new[]
                {
                    MetadataReference.CreateFromFile(string.Format(runtimePath, "mscorlib")),
                    MetadataReference.CreateFromFile(string.Format(runtimePath, "System")),
                    MetadataReference.CreateFromFile(string.Format(runtimePath, "System.Core"))
                };
    
            private static readonly CSharpCompilationOptions DefaultCompilationOptions =
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
                        .WithOverflowChecks(true).WithOptimizationLevel(OptimizationLevel.Release)
                        .WithUsings(DefaultNamespaces);
    
            public static SyntaxTree Parse(string text, string filename = "", CSharpParseOptions options = null)
            {
                var stringText = SourceText.From(text, Encoding.UTF8);
                return SyntaxFactory.ParseSyntaxTree(stringText, options, filename);
            }
    
            static void Main(string[] args)
            {
                var fileToCompile = @"C:\Users\DesktopHome\Documents\Visual Studio 2013\Projects\ConsoleForEverything\SignalR_Everything\Program.cs";
                var source = File.ReadAllText(fileToCompile);
                var parsedSyntaxTree = Parse(source, "", CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.CSharp5));
    
                var compilation
                    = CSharpCompilation.Create("Test.dll", new SyntaxTree[] { parsedSyntaxTree }, DefaultReferences, DefaultCompilationOptions);
                try
                {
                    var result = compilation.Emit(@"c:\temp\Test.dll");
    
                    Console.WriteLine(result.Success ? "Sucess!!" : "Failed");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                Console.Read();
            }
