    using System;
    using System.Linq;
    using System.Reflection;
    
    namespace ConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                var assembly = Assembly.LoadFrom("ConsoleApplication.exe");
                var types = assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(Animal)));
    
                foreach (var type in types)
                    Console.WriteLine(type.Name);
            }
        }
    
        class Animal { }
        class Cat : Animal { }
        class Dog : Animal { }
        class Pig : Animal { }
    }
