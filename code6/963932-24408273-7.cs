    using System;
    using System.Linq;
    
    namespace ConsoleApplication4
    {
        using System.CodeDom.Compiler;
        using System.Reflection;
    
        using Microsoft.CSharp;
    
        class Program
        {
            static void Main(string[] args)
            {
                ExtDll code = new ExtDll();
                string source = code.TransformText();
                CSharpCodeProvider provider = new CSharpCodeProvider();
                CompilerParameters parameters = new CompilerParameters()
                                                {
                                                    GenerateInMemory = true,
                                                    GenerateExecutable = false
                                                };
                parameters.ReferencedAssemblies.AddRange(
                    new[]
                    {
                        "System.Core.dll",
                        "mscorlib.dll"
                    });
                CompilerResults results = provider.CompileAssemblyFromSource(parameters, source);
                if (results.Errors.HasErrors)
                {
                    var errorString = String.Join("\n", results.Errors.Cast<CompilerError>().Select(error => String.Format("Error ({0}): {1}", error.ErrorNumber, error.ErrorText)));
    
                    throw new InvalidOperationException(errorString);
                }
                Assembly assembly = results.CompiledAssembly;
                Func<int,double> squareRoot = (i) => { return Math.Sqrt(i); };
                Type type = assembly.GetType("C");
                //object instance = Activator.CreateInstance(type);
                MethodInfo method = type.GetMethod("MyWrapper4");
                Console.WriteLine(method.Invoke(null, new object[]{squareRoot})); 
            }
        }
    
    }
