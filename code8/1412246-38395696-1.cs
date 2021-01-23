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
            public enum State
            {
                FIND_GROUP,
                GET_GROUP
            }
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(FILENAME);
                string inputLine = "";
                Series series = null;
                State state = State.FIND_GROUP;
                while ((inputLine = reader.ReadLine()) != null)
                {
                    inputLine = inputLine.Trim();
                    if (inputLine.Length > 0)
                    {
                        switch (state)
                        {
                            case State.FIND_GROUP:
                                series = new Series();
                                series.name = inputLine.Replace("�", "");
                                Series.series.Add(series);
                                state = State.GET_GROUP;
                                break;
                            case State.GET_GROUP:
                                string[] numbers = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                series.values.Add(new KeyValuePair<int, List<int>>(
                                    int.Parse(numbers[0]),
                                    numbers[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList()
                                ));
                                break;
                        }
                    }
                    else
                    {
                        state = State.FIND_GROUP;
                    }
                }
            }
         }
        public class Series
        {
            public string name { get; set; }
            public static List<Series> series = new List<Series>();
            public List<KeyValuePair<int, List<int>>> values { get; set; }
            public Series()
            {
                values = new List<KeyValuePair<int, List<int>>>();
            }
         }
     
    }
