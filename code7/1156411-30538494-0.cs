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
                string input = 
                "<Subjects>" +
                   "<Subject>" +
                     "<Name></Name>" +
                     "<Height></Height>" +
                     "<Addresses>" +
                        "<Address>" +
                           "<City>AB</City>" +
                        "</Address>" +
                     "</Addresses>" +
                   "</Subject>" +
                   "<Subject>" +
                     "<Name></Name>" +
                     "<Height></Height>" +
                     "<Addresses>" +
                        "<Address>" +
                           "<City>CD</City>" +
                        "</Address>" +
                     "</Addresses>" +
                   "</Subject>" +
                 "</Subjects>";
                XDocument doc = XDocument.Parse(input);
                foreach (XElement subject in doc.Descendants("Subject"))
                {
                    string address = subject.Element("Addresses").Element("Address").Element("City").Value;
                    XElement newAddress = new XElement("Address");
                    newAddress.Value = address;
                    subject.Add(newAddress);
                    subject.Element("Addresses").Remove();
                }
            }
        }
    }
    ​
