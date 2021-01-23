    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml =
                    "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
                    "<url>\"http://my.xml.org/?id=AAA%2DDDD%3dNNNLKLKJLKL%2\"</url>";
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);
                string results = xmlDoc.SelectSingleNode("url").InnerText;
            }
        }
    }
    ​
