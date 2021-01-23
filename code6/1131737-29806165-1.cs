    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication20
    {
        class Program
        {
            static void Main(string[] args)
            {
                Random rand = new Random();
                List<string> input = new List<string>();
                List<string> output = new List<string>();
                //create 150 random strings with duplicates
                for(int i = 0; i < 150; i++)
                {
                    input.Add(rand.Next(0,25).ToString());
                }
                //create dictionary with two columns key, number of entries
                Dictionary<string, Value> dict = input.AsEnumerable()
                    .GroupBy(x => x)
                    .ToDictionary(x => x.Key, y => new Value { count = y.Count(), ranNumber = rand.Next() });
                dict = dict.OrderBy(x => x.Value.ranNumber).ToDictionary(x => x.Key, y => y.Value);
                //add 1 sorted numbers to output
                foreach(string key in dict.Keys)
                {
                    output.Add(key);
                }
                //add rest of numbers
                foreach (string key in dict.Keys)
                {
                    int numberOfItems = dict[key].count;
                    if (dict[key].count > 1)
                    {
                        int arraySize = output.Count;
                        int spacing = arraySize / numberOfItems;
                        int firstItem = 0;
                        //center around middle
                        if (numberOfItems % 2 == 0)
                        {
                            firstItem = (arraySize / 2) - (((numberOfItems / 2) * spacing) + (spacing / 2));
                        }
                        else
                        {
                            firstItem = (arraySize / 2) - (((numberOfItems - 1) / 2) * spacing);
                        }
                        if (firstItem < 0)
                        {
                            firstItem = 0;
                        }
                        //remove existing item
                        output.Remove(key);
                        //insert items
                        for (int i = 0; i < numberOfItems; i++)
                        {
                            output.Insert(firstItem,key);
                            firstItem += spacing;
                        }
                    }
                }
                
            }
            public class Value
            {
                public int count { get; set; }
                public int ranNumber { get; set; }
            }
        }
    }
