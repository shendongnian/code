    using System;
    using System.Reflection;
    
    namespace InspectRefAssm
    {
        class Program
        {
            static void Main(string[] args)
            {
                if (args.Length < 1 || string.IsNullOrEmpty(args[0]))
                {
                    Console.WriteLine("This program requires an argument to the path of the executable.");
                    Console.WriteLine("Example:");
                    Console.WriteLine(Path.GetFileName(Assembly.GetEntryAssembly().Location) + @" c:\Path\To\Executable.exe");
                    Console.ReadKey(true);
                    return;
                }
                if (!File.Exists(args[0]))
                {
                    Console.WriteLine("File not found.");
                    Console.ReadKey(true);
                    return;
                }
                Assembly asm = Assembly.LoadFile(args[0]);
    
                foreach (AssemblyName asmName in asm.GetReferencedAssemblies())
                {
                    Console.WriteLine(asmName.FullName);
                }
                      
                Console.ReadKey(true);
            }
        }
    }
