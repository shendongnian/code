    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                List<List<int>> data = new List<List<int>>();
                string inputLine = "";
                StreamReader reader = new StreamReader(FILENAME);
                while((inputLine = reader.ReadLine()) != null)
                {
                    inputLine = inputLine.Trim();
                    if (inputLine.Length > 0)
                    {
                        List<int> inputArray = inputLine.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();
                        data.Add(inputArray);
                    }
                }
            }
        }
    }
    ​
