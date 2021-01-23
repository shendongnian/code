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
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<XElement> book = doc.Descendants("book").Where(x => x.Element("title").Value.Contains("Learn")).ToList();
                XDocument filteredDoc = XDocument.Parse("<?xml version=\"1.0\" encoding=\"UTF-8\"?><bookstore></bookstore>");
                XElement root = (XElement)filteredDoc.FirstNode;
                root.Add(book);
            }
        }
    }​
