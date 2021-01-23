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
                List<Item> myList = new List<Item>() { 
                                      new Item()  {Id = 123, Data = "abc"},
                                      new Item()  {Id = 124, Data = "abd"},
                                      new Item()  {Id = 125, Data = "abe"},
                                      new Item()  {Id = 126, Data = "abf"},
                                      new Item()  {Id = 127, Data = "abg"}
                };
                int id = myList.Where(x => x.Data == "abe").Select(y => y.Id).FirstOrDefault();
            }
        }
        public struct Item
        {
            public int Id { get; set; }
            public string Data { get; set; }
        }
    }
    ​
