    var initial = CSharpCompilation.Create("Existing")
        .AddReferences(MetadataReference.CreateFromFile(typeof(object).Assembly.Location))
        .AddSyntaxTrees(SyntaxFactory.ParseSyntaxTree(@"    
            namespace Test
            {
                public class Program
                {
                    public static void HelloWorld()
                    {
                        System.Console.WriteLine(""Hello World"");
                    }
                }
            }"));    
    var method = initial.GetSymbolsWithName(x => x == "HelloWorld").Single();
