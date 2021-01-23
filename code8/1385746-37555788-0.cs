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
                string[] input = {
                    "123, 1/1/2016, 456\n",
                    "456, 1/2/2016, 456\n",
                    "789, 1/3/2016, 456"
                };
                List<MyObject> objects = input.Select(x => x.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries)).Select(y => new MyObject() {ID = int.Parse(y[0]), timeStamp = DateTime.Parse(y[1]), value = int.Parse(y[2])}).ToList();
            }
        }
        public class MyObject
        {
            public int ID { get; set; }
            public DateTime timeStamp { get; set; }
            public int value { get; set; }
        }
    }
