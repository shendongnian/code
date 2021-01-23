        static void Main(string[] args)
        {
            string source =
            @"
                namespace Test
                {
                    public class Test
                    {
                        public void HelloWorld()
                        {
                            System.Console.WriteLine(""Hello World"");
                        }
                    }
                }
            ";
            var options = new Dictionary<string, string> {  {"CompilerVersion", "v3.5"} };
            var provider = new CSharpCodeProvider(options);
            var compilerParams = new CompilerParameters{GenerateInMemory = true,  GenerateExecutable = false };
            var results = provider.CompileAssemblyFromSource(compilerParams, source);
            var method = results.CompiledAssembly.CreateInstance("Test.Test");
            var methodInfo = method.GetType().GetMethod("HelloWorld");
            methodInfo.Invoke(method, null);
        }
