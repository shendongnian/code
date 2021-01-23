    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                var Projects = new List<Project>() {
                    new Project() { Name="Overhead", IsActive=false },
                    new Project() { Name="Nadfadfs", IsActive=false },
                    new Project() { Name="Overhead", IsActive=false },
                    new Project() { Name="dasfasdf", IsActive=false }
                };
                PrintProjectList(Projects);
                Console.WriteLine("--Setting property--");
                Projects.Where(p => p.Name == "Overhead").SetProperty(p => p.IsActive = true);
                PrintProjectList(Projects);
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
    
            static void PrintProjectList(IEnumerable<Project> projects)
            {
                foreach(var p in projects)
                {
                    Console.WriteLine($"Name: {p.Name} IsActive: {p.IsActive}");
                }
            }
        }
    
        class Project
        {
            public string Name { get; set; }
            public bool IsActive { get; set; }
        }
    
        public static class Extensions
        {
            public static IEnumerable<T> SetProperty<T>(this IEnumerable<T> list, Action<T> action)
            {
                foreach (var item in list)
                {
                    action.Invoke(item);
                }
                return list;
            }
        }
    }
