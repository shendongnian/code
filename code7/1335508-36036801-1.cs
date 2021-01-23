    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Linq;
    namespace XDocumentTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    String xml = "<?xml version=\"1.0\"?><rootElement>";
                    xml += "<user id=\"1\"><password>temp</password></user>";
                    xml += "<user id=\"2\"><adminPassword>foobar</adminPassword></user>";
                    xml += "<user id=\"3\"><somePassWORDelement>foobarXYZ</somePassWORDelement></user>";
                    xml += "</rootElement>";
                    XDocument doc = XDocument.Parse(xml);
                    foreach (XElement element in doc.Descendants().Where(
                        e => e.Name.ToString().ToLower().Contains("password")))
                    {
                        Console.WriteLine(element);
                        // Delete your value here. Either changing the text node
                        // or by removing the password node. E.g.
                        element.Value = string.Empty;
                    }
                    Console.WriteLine(doc.ToString());
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
