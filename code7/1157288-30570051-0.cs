    namespace ConsoleApplication1
    {
        using System;
        using System.Reflection;
    
        class Program
        {
            static void Main(string[] args)
            {
                var DLL = Assembly.LoadFile(@"C:\visual studio 2013\Projects\ConsoleApplication1\ConsoleApplication1\DLL.That.Keeps.Crashing.dll");
    
                foreach(Type type in DLL.GetExportedTypes())
                {
                    dynamic c = Activator.CreateInstance(type);
                    //Call a method on the loaded type dynamically
                    c.Output(@"Hello");
                }
    
                Console.ReadLine();
            }
        }
    }
