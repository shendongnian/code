    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Data;
    namespace ConsoleApplication53
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("PID", typeof(int));
                dt.Columns.Add("TT", typeof(string));
                dt.Columns.Add("STAT", typeof(string));
                dt.Columns.Add("TIME", typeof(DateTime));
                dt.Columns.Add("COMMAND", typeof(string));
                StreamReader reader = new StreamReader(FILENAME);
                int lineCount = 0;
                string inputLine = "";
                while ((inputLine = reader.ReadLine) != null)
                {
                    if (++lineCount > 2)
                    {
                        string[] inputArray = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        dt.Rows.Add(new object[] {
                            int.Parse(inputArray[0]),
                            inputArray[1],
                            inputArray[2],
                            DateTime.Parse(inputArray[3]),
                            inputArray[4]
                        });
                    }
                }
            }
        }
    }
