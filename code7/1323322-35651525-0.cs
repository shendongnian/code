    using System;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    
    namespace Test
    {
        public class Row
        {
            public string Cell1 { get; set; } 
            public string Cell2 { get; set; } 
            public string Cell3 { get; set; }  
        }
    
        public class Grid
        {
            public Row Row1 { get; set; } 
            public Row Row2 { get; set; } 
            public Row Row3 { get; set; } 
        }
    
        public class SetOfGrids
        {
            public Grid g1 { get; set; } 
            public Grid g2 { get; set; } 
        }
    
        class Program
        {
            public static object GetPropValue(string name, object obj)
            {
                foreach (string part in name.Split('.'))
                {
                    if (obj == null) { return null; }
    
                    var type = obj.GetType();
                    var info = type.GetProperty(part);
    
                    if (info == null) { return null; }
    
                    obj = info.GetValue(obj, null);
                }
    
                return obj;
            }
    
            public static void Main()
            {
                SetOfGrids sog = new SetOfGrids
                {
                    g1 = new Grid { Row1 = new Row { Cell1 = "cat", Cell2 = "fish", Cell3 = "dog" }, Row2 = new Row { Cell1 = "cat", Cell2 = "fish", Cell3 = "dog" }, Row3 = new Row { Cell1 = "cat", Cell2 = "fish", Cell3 = "dog" } },
                    g2 = new Grid { Row1 = new Row { Cell1 = "cat", Cell2 = "fish", Cell3 = "dog" }, Row2 = new Row { Cell1 = "cat", Cell2 = "fish", Cell3 = "dog" }, Row3 = new Row { Cell1 = "cat", Cell2 = "fish", Cell3 = "dog" } }
                };
    
                string PathToProperty = "g1.Row1.Cell1";
    
                object s = GetPropValue(PathToProperty, sog);
    
                Console.WriteLine(s);
                Console.ReadLine();
            }
        }
    }
