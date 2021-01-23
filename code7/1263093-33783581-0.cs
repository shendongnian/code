    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace CrashTest
    {
        class Program
        {
            public static void Main()
            {
                List<MyObj> objs = new List<MyObj>
                {
                    new MyObj{Id = 1, MyType = "toto"},
                    new MyObj{Id = 1, MyType = "tata"},
                    new MyObj{Id = 1, MyType = "tutu"},
                    new MyObj{Id = 1, MyType = "titi"},
                    new MyObj{Id = 2, MyType = "toto"},
                    new MyObj{Id = 2, MyType = "tata"},
                };
                var g = objs.GroupBy(i => i.Id);
                foreach (var group in g)
                {
                    Console.Out.WriteLine("There is " +  group.Count() + " objs of ID:" + group.Key);
                }
				Console.Out.WriteLine("There is " + g.Count() + " different ids"); 
            }
        }
    
        public class MyObj
        {
            public int Id { get; set; }
            public string MyType { get; set; }
        }
    }
