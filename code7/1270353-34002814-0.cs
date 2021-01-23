    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Device> list = new List<Device>(){
                    new Device(){Power = 3,Current =2}
                    , new Device(){Power = 2, Current = 2}
                    , new Device(){Power = 1, Current = 3}
                };
    
                var sorted = list.OrderByDescending(d=>d.Current).ThenByDescending(d=>d.Power);
    
                foreach (var d in sorted)
                {
                    Console.WriteLine("Current {0}, Power {1}",d.Current,d.Power);
                }
                Console.ReadLine();
            }
        }
    
        class Device
        {
            public int Power {get;set;}
            public int Current { get; set; }
        }
    }
