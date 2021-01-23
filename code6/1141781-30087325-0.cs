    using System;
    using System.Reflection;
    
    namespace InspectRefAssm
    {
        class Program
        {
            static void Main(string[] args)
            {
                Assembly asm = Assembly.LoadFile(args[0]);
    
                foreach (AssemblyName asmName in asm.GetReferencedAssemblies())
                {
                    Console.WriteLine(asmName.FullName);
                }
                      
                Console.ReadKey(true);
            }
        }
    }
