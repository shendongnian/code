    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
    class Program
    {
        //private static XElement AccountData = new XElement("Root");
        private static DataSet dataSet = new DataSet();
        static void Main(string[] args)
        {
            DataSet dataSet = new DataSet();
            string[] readText = File.ReadAllLines(@"<Path to your account data file>\AccountData.txt");
            string strAccountNumber = string.Empty;
            string strPin = string.Empty;
            string strName = string.Empty;
            dataSet.ReadXml(new StringReader(new XElement("Root",
                                from str in readText
                                let fields = str.Split('*')
                                select new XElement("AccountData",
                                    new XAttribute("AccountNo", fields[0]),
                                    new XAttribute("Name", fields[1]),
                                    new XAttribute("Pin", fields[2]),
                                    new XAttribute("ChkBalance", fields[3]),
                                    new XAttribute("SavBalance", fields[4])
                                )
                            ).ToString()));
            do
            {
                Console.WriteLine("Please enter your Account Number (press 'Q' to exit)");
                strAccountNumber = Console.ReadLine().ToLower();
                if (dataSet.Tables[0].Select(string.Format("AccountNo = '{0}'", strAccountNumber)).Count() == 1)
                {
                    Console.WriteLine("Please enter your Pin");
                    strPin = Console.ReadLine().ToLower();
                    Console.WriteLine("Please enter your Name");
                    strName = Console.ReadLine();
                    if (dataSet.Tables[0].Select(string.Format("Pin = '{0}' AND Name = '{1}'", strPin, strName)).Count() == 1)
                    {
                        DataRow[] result = dataSet.Tables[0].Select(string.Format("Pin = '{0}' AND Name = '{1}'", strPin, strName));
                        foreach (DataRow row in result)
                        {
                            Console.WriteLine(string.Format("Account Info for :: {0}", strName));
                            Console.WriteLine("{0}, {1}, {2}, {3}, {4}", row[0], row[1], row[2], row[3], row[4]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Details");
                    }
                }
            } while (strAccountNumber != "q");
        }
    }
    }
