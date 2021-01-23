    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument callvalidate = XDocument.Load(FILENAME);
                XElement bankAccountNumber = callvalidate.Descendants("Bankaccountnumber").FirstOrDefault();
                XElement newBankAccountNumber = new XElement("Bankaccountnumber", new object[] {
                    23232323,
                    new XElement("Banksortcode",232323)
                });
                bankAccountNumber = newBankAccountNumber;
            }
        }
    }
    ​
