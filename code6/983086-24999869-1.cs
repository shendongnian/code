    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var assemblies = AppDomain.CurrentDomain.GetAssemblies();
                var types = new List<Type>();
    
                foreach (var assembly in assemblies)
                    types.AddRange(assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(Animal))));
    
                foreach (var item in types)
                    Console.WriteLine(item.Name);
            }
        }
    
        class Animal { }
    
        enum AllAnimals { Cat, Dog, Pig };
        class Cat : Animal { }
        class Dog : Animal { }
        class Pig : Animal { }
    }
