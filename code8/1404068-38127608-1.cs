    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.IO;
    namespace ConsoleApplication106
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                string inputLine = "";
                List<Data> data = new List<Data>();
                string pattern = @"(?'prefix'\w*)?\s*?(?'index'\d+):(?'text'.*)";
                StreamReader reader = new StreamReader(FILENAME);
                while ((inputLine = reader.ReadLine()) != null)
                {
                    inputLine = inputLine.Trim();
                    Match match = Regex.Match(inputLine, pattern);
                    Data newData = new Data();
                    data.Add(newData);
                    newData.prefix = match.Groups["prefix"].Value;
                    newData.index = int.Parse(match.Groups["index"].Value);
                    newData.text = match.Groups["text"].Value;
                }
            }
        }
        public class Data
        {
            public string prefix { get; set; }
            public int index { get; set; }
            public string text { get; set; }
        }
    }
