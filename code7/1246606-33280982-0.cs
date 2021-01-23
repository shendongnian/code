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
                List<Data> inputs = new List<Data>() {
                    new Data() { date = DateTime.Parse("10/22/15 6:00AM"), data = "abc"},
                    new Data() { date = DateTime.Parse("10/22/15 4:00AM"), data = "def"},
                    new Data() { date = DateTime.Parse("10/22/15 6:30AM"), data = "ghi"},
                    new Data() { date = DateTime.Parse("10/22/15 12:00AM"), data = "jkl"},
                    new Data() { date = DateTime.Parse("10/22/15 3:00AM"), data = "mno"},
                    new Data() { date = DateTime.Parse("10/22/15 2:00AM"), data = "pqr"},
                };
                Data data = new Data();
                foreach (Data input in inputs)
                {
                    data.Add(input);
                }
            }
        }
        public class Data
        {
            public static List<Data> sortedData = new List<Data>();
            public DateTime date { get; set; }
            public string data { get; set;}
            public void Add(Data newData)
            {
                if(sortedData.Count == 0)
                {
                    sortedData.Add(newData);
                }
                else
                {
                   Boolean added = false;
                   for(int index = sortedData.Count - 1; index >= 0; index--)
                   {
                       if(newData.date > sortedData[index].date)
                       {
                           sortedData.Insert(index + 1, newData);
                           added = true;
                           break;
                       }
                   }
                   if (added == false)
                   {
                       sortedData.Insert(0, newData);
                   }
                }
            }
        }
    }​
