    using System;
    using System.CodeDom.Compiler;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;
    using Microsoft.CSharp;
     
    namespace ConsoleApplication212
    {
        class Program
        {
            static void Main(string[] args)
            {
                //dynamic code
                var source = @"
                static class Program
                {
                    public static void Start()
                    {
                        //We call the Test method of the class Console Application 212.Helper
                        ConsoleApplication212.Helper.Test();
                    }
                }";
     
                //compile and run
                Run(source);
     
                Console.ReadLine();
            }
     
            static void Run(string source)
            {
                using (var provider = new CSharpCodeProvider())
                {
                    var parameters = new CompilerParameters { GenerateInMemory = true };
     
                    parameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
                    //link your self
                    parameters.ReferencedAssemblies.Add(Path.GetFileName(Assembly.GetExecutingAssembly().CodeBase));
     
                    //compile
                    var result = provider.CompileAssemblyFromSource(parameters, source);
                    if (result.Errors.Count > 0)
                        throw new Exception(result.Errors[0].ErrorText);
     
                    //Find class Program
                    var type = result.CompiledAssembly.GetType("Program");
                    //вызыаем метод Start
                    type.GetMethod("Start").Invoke(null, null);
                }
            }
        }
     
        /// <summary>
        /// Public class that will be used in dynamically compiled code
        /// </summary>
        public static class Helper
        {
            public static void Test()
            {
                MessageBox.Show("Hi from Helper");
            }
        }
    }
