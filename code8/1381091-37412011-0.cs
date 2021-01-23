    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication93
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                List<List<double>> data = new List<List<double>>();
                StreamReader reader = new StreamReader(FILENAME);
                string inputLine = "";
                Boolean endHeader = false;
                while ((inputLine = reader.ReadLine()) != null)
                {
                    inputLine = inputLine.Trim();
                    if (inputLine.Length > 0)
                    {
                        if(endHeader)
                        {
                            List<double> newRow = inputLine.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToList();
                            data.Add(newRow);
                        }
                        else
                        {
                            if(inputLine.Contains("end_header"))
                            {
                                endHeader = true;
                            }
                        }
                    }
                }
               
            }
        }
    }
