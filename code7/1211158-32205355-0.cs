    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"C:\temp\test.txt";
            static void Main(string[] args)
            {
                string input = File.ReadAllText(FILENAME);
                string pattern = @"(?'type'\w+)\s+\[(?'array'[^\]]+)\]";
                Regex expr = new Regex(pattern, RegexOptions.Singleline);
                MatchCollection matches = expr.Matches(input);
                //Lists to be populated
                List<List<int>> points = new List<List<int>>();
                List<List<int>> coords = new List<List<int>>();
                foreach (Match match in matches)
                {
                    
                    string type = match.Groups["type"].Value;
                    string strArray = match.Groups["array"].Value;
                    StringReader reader = new StringReader(strArray);
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        line = line.Trim();
                        if (line.Length > 0)
                        {
                            List<int> intArray = line.Split(new char[] { ',', ' '}, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();
                            switch (type)
                            {
                                case "point":
                                    points.Add(intArray);
                                    break;
                                case "coordIndex":
                                    coords.Add(intArray);
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
    ​
