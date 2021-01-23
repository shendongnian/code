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
                string XMLContent = "";
                //using XML
                XmlDocument doc1 = new XmlDocument();
                doc1.LoadXml(XMLContent);
                //using xml linq
                XDocument doc2 = XDocument.Parse(XMLContent);
            }
        }
    }
    ​
