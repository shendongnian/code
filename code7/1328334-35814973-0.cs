        using System;
        using System.Collections.Generic;
        using System.Linq;
        
        namespace SimpleTree
        {
            public class Program
            {
                private static void Main(string[] args)
                {
                    var categories = new List<Category>()
                    {
                        new Category {Id = 1, Name = "tag 1"},
                        new Category {Id = 2, Name = "tag 2", ParentId = 1},
                        new Category {Id = 3, Name = "tag 3", ParentId = 1},
                        new Category {Id = 4, Name = "tag 4", ParentId = 2},
                        new Category {Id = 5, Name = "tag 5"},
                        new Category {Id = 6, Name = "tag 6"},
                    };
        
                    foreach (var category in categories)
                    {
                        category.Parent = FindParent(categories, category.ParentId);
                    }
        
                    //pretty printing with indentation is left as an exercise for you :)
                    foreach (var category in categories)
                    {
                        Console.WriteLine("ID:{0} Name:{1} ParentID:{2}", category.Id, category.Name, category.ParentId);
                    }
                    Console.ReadLine();
                }
                
                private static Category FindParent(IEnumerable<Category> categories, long? parentId)
                {
                    if (parentId == null) return null;
                    return categories.FirstOrDefault(c => c.Id == parentId);
                }
            }
        
        
            public class Category 
            {
                public virtual long Id { get; set; }
                public virtual string Name { get; set; }
                public virtual Category Parent { get; set; }
                public virtual long? ParentId { get; set; }
            }
        }
