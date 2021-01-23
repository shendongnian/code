    using System;
    using System.Reflection;
    class Program {
        static void Main(string[] args) {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            var path = @"c:\projects2\consoleapplication115\classlibrary1\bin\debug"
                       + @"\ClassLibrary1.dll";
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            var asm = Assembly.Load(bytes);
            try {
                var obj = asm.CreateInstance("ClassLibrary1.Class1");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            Console.ReadLine();
        }
        static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args) {
            throw new Exception("Assembly.Load really does fire AssemblyResolve for " + args.Name);
        }
    }
