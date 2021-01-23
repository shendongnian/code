    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    
    namespace test
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var x = new System();
                x.Stuff = "things";
                Console.WriteLine(x.Stuff);
            }
        }
    
        public class @System
        {
            public string Stuff { get; set; }
    
        }
    }
