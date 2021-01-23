    using System;
    using System.Linq;
    using System.Reflection;
    namespace SO_38487353
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var attributes = typeof(Program).GetTypeInfo().Assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute));
                var assemblyTitleAttribute = attributes.SingleOrDefault() as AssemblyTitleAttribute;
    
                Console.WriteLine(assemblyTitleAttribute?.Title);
                Console.ReadKey();
            }
        }
    }
