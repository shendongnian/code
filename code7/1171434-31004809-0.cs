    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input =
                 "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                 "<Root>" +
                    "<Word1>Trying</Word1>" +
                    "<Word2>To</Word2>" +
                    "<Word3>Learn</Word3>" +
                 "</Root>";
                XDocument doc = XDocument.Parse(input);
                var results = doc.Descendants("Root").Select(x => new {
                    word1 = x.Element("Word1").Value,
                    word2 = x.Element("Word2").Value,
                    word3 = x.Element("Word3").Value
                }).FirstOrDefault();
            }
        }
    }
    ​
