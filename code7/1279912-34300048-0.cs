    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            public abstract class Animal
            {
                public int Age { get; set; }
            }
    
            public class Cat : Animal
            {
                public string Name { get; set; }
    
                public string Type { get; set; }
            }
    
            public class ProblemClass
            {
                public string Name { get; set; }
            }
    
            private static IList<Type> GetAllDerivedTypes(Type t)
            {
                var listOfBs = (from domainAssembly in AppDomain.CurrentDomain.GetAssemblies()
                                from assemblyType in domainAssembly.GetTypes()
                                where t.IsAssignableFrom(assemblyType)
                                select assemblyType);
                return listOfBs.ToList();
            }
    
            private static void MapAllTypes(Type srcType, Type destType)
            {
                var allDestTypes = GetAllDerivedTypes(destType);
                foreach (var destTypeDerived in allDestTypes)
                {
                    Mapper.CreateMap(srcType, destTypeDerived);
                }
            }
    
            static void Main(string[] args)
            {
                MapAllTypes(typeof(ProblemClass), typeof(Animal));
    
                var problemClass = new ProblemClass() { Name = "test name" };
                Animal someAnimal = new Cat();
    
                // after this (someAnimal as Cat).Name will be "test name"
                Mapper.Map(problemClass, someAnimal);
            }
        }
    }
