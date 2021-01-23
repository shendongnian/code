    using System;
    using System.CodeDom.Compiler;
    using Microsoft.CSharp;
    using System.Diagnostics;
    
    namespace ConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                var compiler = new CSharpCodeProvider();
                var parameters = new CompilerParameters(new[] { "mscorlib.dll", "System.Core.dll" }, "foo.exe", true);
                parameters.CompilerOptions = "/platform:x64";
                parameters.GenerateExecutable = true;
    
                CompilerResults results = compiler.CompileAssemblyFromSource(parameters,
                                        @"using System;
                                         class Program {
                                               public static void Main(string[] args) {
                                               Console.WriteLine(""Hello world!"");
                                               Console.ReadLine();
                                               }
                                          }");
            
                var testProcess = new Process();
                testProcess.StartInfo.FileName = results.CompiledAssembly.CodeBase;
                testProcess.Start();
    
                Console.WriteLine("I've run slave!");
    
                Console.ReadLine();
            }
        }
    }
