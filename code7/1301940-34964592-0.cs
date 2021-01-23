    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Business> businessList = new List<Business>
                {
                  new Business {ID = 1,NAME = "A"},
                  new Business {ID = 1,NAME = "B"},
                  new Business {ID = 1,NAME = "C"},
                  new Business {ID = 2,NAME = "D"},
                  new Business {ID = 2,NAME = "E"},
                  new Business {ID = 2,NAME = "F"},
                  new Business {ID = 3,NAME = "G"},
                  new Business {ID = 4,NAME = "H"},
                  new Business {ID = 4,NAME = "I"},
                  new Business {ID = 4,NAME = "J"},
                  new Business {ID = 5,NAME = "K"},
                  new Business {ID = 5,NAME = "L"}
                };
                Dictionary<int, List<string>> dict = businessList.AsEnumerable()
                    .GroupBy(x => x.ID, y => y.NAME)
                    .ToDictionary(x => x.Key, y => y.ToList());
           }
            public class Business
            {
                public int ID { get; set; }
                public string NAME { get; set; }
            }
        }
    }
