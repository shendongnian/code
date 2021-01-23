    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication62
    {
        class Program
        {
            const string FOLDER = @"\c:\temp";
            static void Main(string[] args)
            {
                string[] filenames = Directory.GetFiles(FOLDER);
                foreach (string file in filenames)
                {
                    XDocument tempXml = XDocument.Load(file);
                    XElement root = (XElement)tempXml.FirstNode;
                    XNamespace  nsMgr = root.Name.Namespace;
                    XElement node = root.Descendants(nsMgr + "TagName").FirstOrDefault();
                }
            }
        }
    }
