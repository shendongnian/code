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
                List<XElement> bankAccountNumbers = callvalidate.Descendants("Bankaccountnumber").ToList();
                for(int index = 0; index < bankAccountNumbers.Count; index++)
                {
                    XElement bankAccountNumber = bankAccountNumbers[index];
                    int accountNumber = int.Parse(bankAccountNumber.Value);
                    XElement newBankAccountNumber = new XElement("Bankaccountnumber", new object[] {
                        accountNumber,
                        new XElement("Banksortcode",accountNumber)
                    });
                    bankAccountNumber = newBankAccountNumber;
                }
            }
        }
    }
    ​
