    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace SO_Test
    {
        public class ObjectA
        {
            public int Property1 { get; set; }
            public int? Property2 { get; set; }
    
            public override string ToString()
            {
                return String.Format("({0}, {1})", Property1, Property2);
            }
        }
    
        public class ObjectB
        {
            public int Property1 { get; set; }
            public int? Property2 { get; set; }
    
            public override string ToString()
            {
                return String.Format("({0}, {1})", Property1, Property2);
            }
        }
    
        class Program
        {
            static void Main()
            {
                var listA = new List<ObjectA>
                { 
                    new ObjectA { Property1 = 5,  Property2 = null }, 
                    new ObjectA { Property1 = 16, Property2 = null }, 
                    new ObjectA { Property1 = 9,  Property2 = null }, 
                    new ObjectA { Property1 = 38, Property2 = null } 
                };
                var listB = new List<ObjectB>
                { 
                    new ObjectB { Property1 = 5, Property2 = 1 }, 
                    new ObjectB { Property1 = 9, Property2 = 2 }, 
                    new ObjectB { Property1 = 16, Property2 = 3 } 
                };
    
                Console.WriteLine("BEFORE");
                Console.WriteLine("ListA: {0}", String.Join(",", listA));
                Console.WriteLine("ListB: {0}", String.Join(",", listB));
    
                listA.ForEach(a =>
                    a.Property2 = listB.Where(b => b.Property1 == a.Property1)
                                       .Select(r => r.Property2).FirstOrDefault());
                
                Console.WriteLine("AFTER");
                Console.WriteLine("ListA: {0}", String.Join(", ", listA));
                Console.WriteLine("ListB: {0}", String.Join(", ", listB));
                Console.ReadLine();
            }
        }
    }
