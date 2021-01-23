    using System;
    using System.CodeDom.Compiler;
    using System.Reflection;
    using Microsoft.CSharp;
    
    namespace stringToCode
    {
        public class Program
        {
            public static int q = 0;
            static void Main(string[] args)
            {
                string source = "namespace stringToCode { public class FooClass { public void Execute() { Program.q = 1; } } }";
    
                Console.WriteLine("q=" + q);
                using (var foo = new CSharpCodeProvider())
                {
                    var parameters = new CompilerParameters();
                    parameters.GenerateInMemory = true;
    
                    foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                    {
                        try
                        {
                            string location = assembly.Location;
                            if (!String.IsNullOrEmpty(location))
                            {
                                parameters.ReferencedAssemblies.Add(location);
                            }
                        }
                        catch (NotSupportedException)
                        {}
                    } 
    
                    var res = foo.CompileAssemblyFromSource(parameters ,source);
                    var type = res.CompiledAssembly.GetType("stringToCode.FooClass"); //<- here i has error
                    var obj = Activator.CreateInstance(type);
                    var output = type.GetMethod("Execute").Invoke(obj, new object[] { });
    
                    Console.WriteLine("q=" + q);
                    Console.ReadLine();
                }
            }
        }
    }
