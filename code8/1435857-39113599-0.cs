    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml =
                    "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                    "<cat:Catalogue xmlns=\"http://www.somewhere.org/BookCatalogue\" xmlns:cat=\"http://www.somewhere.org/BookCatalogue\" xmlns:html=\"http://www.somewhere.org/HTMLCatalogue\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"http://www.somewhere.org/BookCatalogue                         txjsgen14.txt\">" +
                      "<cat:Magazine>" +
                        "<cat:Title>Natural Health</cat:Title>" +
                        "<cat:Author>October</cat:Author>" +
                        "<cat:Date>December, 1999</cat:Date>" +
                        "<cat:Volume>12</cat:Volume>" +
                        "<cat:htmlTable>" +
                        "</cat:htmlTable>" +
                      "</cat:Magazine>" +
                      "<cat:Magazine>" +
                        "<cat:Title>Natural Health</cat:Title>" +
                        "<cat:Author>October</cat:Author>" +
                        "<cat:Date>December, 1999</cat:Date>" +
                        "<cat:Volume>12</cat:Volume>" +
                        "<cat:htmlTable>" +
                        "</cat:htmlTable>" +
                      "</cat:Magazine>" +
                    "</cat:Catalogue>";
                StringReader sReader = new StringReader(xml);
                XmlReader xReader = XmlReader.Create(sReader);
                xReader.MoveToContent();
                XNamespace ns = xReader.LookupNamespace(xReader.Prefix);
                while (!xReader.EOF)
                {
                    if (xReader.LocalName != "Magazine")
                    {
                        xReader.ReadToFollowing("Magazine", ns.NamespaceName);
                    }
                    if(!xReader.EOF)
                    {
                        XElement magazine = (XElement)XElement.ReadFrom(xReader);
                        string title = (string)magazine.Element(ns + "Title");
                    }
                }
            }
        }
    }
