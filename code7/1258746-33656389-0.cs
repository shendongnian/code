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
            static void Main(string[] args)
            {
                string xml =
                    "<Fatca xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns=\"http://tempuri.org/TaskDetails.xsd\">" +
                    "<AccountNumber>BI830418</AccountNumber>" +
                      "<AccountDetails>" +
                        "<AccountName>SIPP - Mr. t test</AccountName>" +
                        "<AccountNumber>BI830418</AccountNumber>" +
                        "<AccountID>83041</AccountID>" +
                        "<BankAccountDetails>" +
                          "<BankAccountID>23943</BankAccountID>" +
                          "<ContactID>2106175</ContactID>" +
                          "<BankAccountName>dffdf</BankAccountName>" +
                          "<BankAccountNumber>N14yKOOmpdmh23fmp7oNvg==</BankAccountNumber>" +
                          "<BankAccountType>0</BankAccountType>" +
                          "<BankSortCode>tz7r+uYFL6Ff86mI/mwJOQ==</BankSortCode>" +
                          "<Active>true</Active>" +
                        "</BankAccountDetails>" +
                        "<Active>true</Active>" +
                      "</AccountDetails>" +
                      "<Request>" +
                        "<AccountID>83041</AccountID>" +
                      "</Request>" +
                    "</Fatca>";
                XElement fatca = XElement.Parse(xml);
                XNamespace ns = fatca.Name.Namespace;
                 fatca.Descendants(ns + "BankAccountNumber").FirstOrDefault().Value = "TEST";
                Console.WriteLine(fatca.ToString());
            }
        }
    }
    ​
