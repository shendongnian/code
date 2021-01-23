    internal class Program {
        private static void Main(string[] args) {
            new Class1().Test(); // otherwise DummyDll will not be referenced.
            var asm = Mono.Cecil.AssemblyDefinition.ReadAssembly(Assembly.GetEntryAssembly().Location);
            foreach (var reference in asm.MainModule.AssemblyReferences) {
                if (reference.FullName.Contains("DummyDll"))
                    Console.WriteLine(reference.FullName);
            }
            Console.WriteLine();
            Console.WriteLine(typeof(Class1).Assembly.FullName);
            Console.WriteLine();
            foreach (var referenced in Assembly.GetEntryAssembly().GetReferencedAssemblies()) {
                if (referenced.FullName.Contains("DummyDll"))
                Console.WriteLine(referenced.FullName);
            }
            Console.WriteLine();
            var asm2 = Assembly.ReflectionOnlyLoad(Assembly.GetEntryAssembly().FullName);            
            foreach (var referenced in asm2.GetReferencedAssemblies()) {
                if (referenced.FullName.Contains("DummyDll"))
                    Console.WriteLine(referenced.FullName);
            }            
            Console.ReadKey();
        }
    }
