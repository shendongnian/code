    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication9
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                List<object> x = new List<object>();
                x.Add(new MyTypeA());
                x.Add(new MyTypeB());
                foreach (var itemsOfA in x.Where(o => o.GetType().Name == "MyTypeA"))
                {
                    Console.WriteLine("Found a " + itemsOfA.GetType());
                }
            }
        }
    
        class MyTypeA { }
        class MyTypeB { }
    }
