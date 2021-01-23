    using System.IO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Program
    {
        static void Main()
        {
            var values = new List<string>{"a","b","c","d","e","a","b","c","d","e","a","b","c","d","e"};
            var order = new List<string>{"a","b","c","d","e"};
            
            var sortedList = SortByList(values, order);
            
            foreach(var i in sortedList)
            {
                Console.WriteLine(i);
            }
        }
        public static List<string> SortByList(List<string> values, List<string> order){
            return values.OrderBy(x => order.IndexOf(x)).ToList();
        }
    }
