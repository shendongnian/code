    using System;
    using System.Reflection;
    
    namespace ConsoleApp1
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var assemblyName = new AssemblyName("ConsoleApp1");
                var resources = string.Join(Environment.NewLine, Assembly.Load(assemblyName).GetManifestResourceNames());
                Console.WriteLine("List of Manifest Resource Names");
                Console.WriteLine("======================");
                Console.WriteLine(resources);
            }
        }
    }
