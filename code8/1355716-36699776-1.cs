    using System;
    using System.Reflection;
    [assembly:AssemblyVersionAttribute("1.2.3")]
    namespace Test
    {
        class Program
        {
            public static void Main()
            {
                var assembly = typeof(Program).GetTypeInfo().Assembly;
                var name = assembly.GetName();
                Console.WriteLine($"{name.Name}: {name.Version}");
            }
        }
    }
