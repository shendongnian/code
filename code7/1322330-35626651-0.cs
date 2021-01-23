    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
    class Program
    {
        private static XElement AccountData = new XElement("Root");
        static void Main(string[] args)
        {
            string[] readText = File.ReadAllLines(@"<Put the path to you data here>\AccountData.txt");
            string strAccountNumber = string.Empty;
            string strPin = string.Empty;
            string strName = string.Empty;
            for (int i = 0; i <= readText.Count(); i++)
            {
                string[] readRecord = readText.ToArray();
                AccountData = new XElement("Root",
                                    from str in readRecord
                                    let fields = str.Split('*')
                                    select new XElement("AccountData",
                                        new XAttribute("AccountNo", fields[0]),
                                        new XAttribute("Name", fields[1]),
                                        new XAttribute("Pin", fields[2]),
                                        new XAttribute("ChkBalance", fields[3]),
                                        new XAttribute("SavBalance", fields[4])
                                    )
                                );
            }
            do
            {
                Console.WriteLine("Please enter your Account Number (press 'Q' to exit)");
                strAccountNumber = Console.ReadLine().ToLower();
                List<XElement> Account = (from acc in AccountData.Elements("AccountData") where (string)acc.Attribute("AccountNo") == strAccountNumber select acc).ToList();
                if (Account.Count > 0)
                {
                    Console.WriteLine("Please enter your Pin");
                    strPin = Console.ReadLine().ToLower();
                    Console.WriteLine("Please enter your Name");
                    strName = Console.ReadLine();
                    Account = (from acc in AccountData.Elements("AccountData") where (string)acc.Attribute("Pin") == strPin & (string)acc.Attribute("Name") == strName select acc).ToList();
                    if (Account.Count > 0)
                    {
                        foreach (var result in Account)
                        {
                            Console.WriteLine("result...");
                            foreach (var element in result.Attributes())
                            {
                                Console.WriteLine("{0} :: {1}", element.Name, element.Value);
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect Aount Number");
                }
            } while (strAccountNumber != "q" && strAccountNumber != "Q");
        }
    }
    }
