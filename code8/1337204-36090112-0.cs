    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Linq;
    namespace XmlDocumentTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(@"C:\java\xml\root.xml");
                    var root = doc.DocumentElement;
                    var productNode = root.FirstChild;
                    var elementsToRemove = new List<XmlElement>();
                    foreach (XmlElement element in root.GetElementsByTagName("Project"))
                    {
                        elementsToRemove.Add(element);
                    }
                    foreach (XmlElement element in root.GetElementsByTagName("Main"))
                    {
                        elementsToRemove.Add(element);
                    }
                    var maintList = new List<XmlElement>();
                    foreach (XmlElement element in root.GetElementsByTagName("Maintainance"))
                    {
                        maintList.Add(element);
                    }
                    foreach (XmlElement element in maintList)
                    {
                        var newNode = element.CloneNode(true);
                        element.ParentNode.ParentNode.AppendChild(newNode);
                    }
                    foreach (XmlElement element in root.GetElementsByTagName("Status"))
                    {
                        elementsToRemove.Add(element);
                    }
                    foreach (XmlElement element in elementsToRemove)
                    {
                        element.ParentNode.RemoveChild(element);
                    }
                    Console.WriteLine("Xml: " + doc.OuterXml);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                while (Console.ReadKey(true).Key != ConsoleKey.Escape)
                {
                }
            }
        }
    }
