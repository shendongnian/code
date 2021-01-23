    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication85
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                string inputLine = "";
                StreamReader reader = new StreamReader(FILENAME);
                List<string> group = null;
                while ((inputLine = reader.ReadLine()) != null)
                {
                    inputLine = inputLine.Trim();
                    if (inputLine.Length == 0)
                    {
                        if (group != null)
                        {
                            ProcessData(group);
                            group = null;
                        }
                    }
                    else
                    {
                        if (group == null)
                        {
                            group = new List<string>();
                        }
                        group.Add(inputLine);
                    }
                }
                //process last group if there wasn't a blank line at end of group
                if (group != null) ProcessData(group);
            }
            static void ProcessData(List<string> data)
            {
                int a = 0;
            }
        }
    }
