    using System;
    using System.CodeDom;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Reflection;
    using Microsoft.CSharp;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            static void Main(string[] args)
            {
    
                string code = @"
                                using System;
                                using System.Collections.Generic;
    
                                namespace Dynamic1
                                {
                                    public class Test
                                    {
                                        public static IEnumerable<int> Test1()
                                        {
                                           for(int i=0;i<=5;i++)
                                            {
                                                yield return i;
                                            }
                                        }
                                    }
                                }
                            ";
                CSharpCodeProvider provider = new CSharpCodeProvider();
                CompilerParameters parameters =new CompilerParameters();
                CompilerResults results = provider.CompileAssemblyFromSource(parameters, code);
                Assembly assembly = results.CompiledAssembly;
                Type program = assembly.GetType("Dynamic1.Test");
                MethodInfo main = program.GetMethod("Test1");
                IEnumerable<int> outputResults = (IEnumerable<int>)main.Invoke(null, null);
                foreach (var result in outputResults)
                {
                    Console.WriteLine(result);
                }
                Console.ReadLine();
            }
        }
