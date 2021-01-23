    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication3
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(FILENAME);
                string inputLine = "";
                Series series = null;
                while ((inputLine = reader.ReadLine()) != null)
                {
                    inputLine = inputLine.Trim();
                    if (inputLine.Length > 0)
                    {
                        if (inputLine.StartsWith("Series"))
                        {
                            series = new Series();
                            Series.series.Add(series);
                        }
                        else
                        {
                            string[] numbers = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            series.values.Add(new KeyValuePair<int,List<int>>(
                                int.Parse(numbers[0]),
                                numbers[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList()
                            ));
                        }
                    }
                }
            }
         }
        public class Series
        {
            public static List<Series> series = new List<Series>();
            public List<KeyValuePair<int, List<int>>> values { get; set; }
            public Series()
            {
                values = new List<KeyValuePair<int, List<int>>>();
            }
         }
     
    }
