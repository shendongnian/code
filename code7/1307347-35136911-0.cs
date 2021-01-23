    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.Linq;
    using System.Text;
    
    namespace ZipCodeSearchTest
    {
        struct zipCodeEntry
        {
            public string ZipCode { get; set; }
            public string City { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                List<zipCodeEntry> zipCodes = new List<zipCodeEntry>();
    
                string dataFileName = "free-zipcode-database.csv";
                using (FileStream fs = new FileStream(dataFileName, FileMode.Open, FileAccess.Read))
                using (StreamReader sr = new StreamReader(fs))
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] lineVals = line.Split(',');
                        zipCodes.Add(new zipCodeEntry { ZipCode = lineVals[1].Trim(' ', '\"'), City = lineVals[3].Trim(' ', '\"') });
                    }
    
                bool terminate = false;
                while (!terminate)
                {
                    Console.WriteLine("Enter zip code:");
                    var userEntry = Console.ReadLine();
                    if (userEntry.ToLower() == "x" || userEntry.ToString() == "q")
                        terminate = true;
                    else
                    {
                        DateTime dtStart = DateTime.Now;
                        foreach (var arrayVal in zipCodes.Where(z => z.ZipCode == userEntry.PadLeft(5, '0')))
                            Console.WriteLine(string.Format("ZipCode: {0}", arrayVal.ZipCode).PadRight(20, ' ') + string.Format("City: {0}", arrayVal.City));
                        DateTime dtStop = DateTime.Now;
                        Console.WriteLine();
                        Console.WriteLine("Lookup time: {0}", dtStop.Subtract(dtStart).ToString());
                        Console.WriteLine("\n\n");
                    }
                }
            }
        }
    }
