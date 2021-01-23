    using System.CodeDom.Compiler;
    class Program
    {
        static void Main(string[] args)
        {
            var provider = CodeDomProvider.CreateProvider("C#");
            string[] sources = {
                                   @"public abstract class BaseClass { public abstract void Test(); }",
                                   @"public class CustomGenerated : BaseClass { public override void Test() { System.Console.WriteLine(""Hello World""); } }"
                               };
            var results = provider.CompileAssemblyFromSource(new CompilerParameters() {
                GenerateExecutable = false,
                ReferencedAssemblies = { "System.dll", "System.Core.dll" },
                IncludeDebugInformation = true,
                CompilerOptions = "/platform:anycpu"
            }, sources);
            if (results.Errors.Count > 0)
            {
                Console.WriteLine("{0} errors", results.Errors.Count);
                foreach(CompilerError error in results.Errors)
                {
                    Console.WriteLine("{0}: {1}", error.ErrorNumber, error.ErrorText);
                }
            }
            else
            {
                var type = results.CompiledAssembly.GetType("CustomGenerated");
                object instance = Activator.CreateInstance(type);
                type.GetMethod("Test").Invoke(instance, null);
            }
        }
    }
