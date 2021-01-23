    using System;
    
    namespace ConsoleApp14
    {
        using System.Collections.Generic;
        using System.Linq;
    
        internal class Course
        {
            public string Id { get; set; }
    
            public string Name { get; set; }
    
            public List<string> Dependencies { get; set; }
    
            public int? DependencyDepth { get; set; }
    
            public override string ToString()
            {
                return Name;
            }
        }
    
        internal class Program
        {
            private static string data = "N01 Math 0\n" 
                                       + "N02 Physics 1 N01\n"
                                       + "N03 Chemistry 2 N01 N02\n"
                                       + "N04 Sports 0\n"
                                       + "N05 Logic 1 N04\n"
                                       + "N06 Music 1 N05\n"
                                       + "N07 Theatre 2 N03 N06\n"
                                       + "N08 Law 1 N03\n"
                                       + "N09 OS 2 N07 N08\n";
    
            private static int DependencyDepth(Course course, List<Course> courses)
            {
                if (!course.DependencyDepth.HasValue)
                {
                    if (!course.Dependencies.Any())
                    {
                        course.DependencyDepth = 0;
                    }
                    else
                    {
                        course.DependencyDepth = 1 + course.Dependencies.Max(dep => DependencyDepth(courses.First(c => c.Id == dep), courses));
                    }
                }
    
                return course.DependencyDepth.Value;
            }
    
            static void Main()
            {
                var courses = data.Split("\n", StringSplitOptions.RemoveEmptyEntries)
                                  .Select(line => line.Split(" "))
                                  .Select(parts => new Course { Id = parts[0], Name = parts[1], Dependencies = parts.Skip(3).ToList() })
                                  .ToList();
    
                courses.ForEach(course => DependencyDepth(course, courses));
    
                courses.OrderBy(course => course.DependencyDepth).ToList().ForEach(Console.WriteLine);
                
                Console.ReadLine();
            }
        }
    }
