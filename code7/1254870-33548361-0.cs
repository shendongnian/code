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
                    "<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"yes\"?>" +
                    "<w:document xmlns:w=\"http://schemas.openxmlformats.org/wordprocessingml/2006/main\">" +
                        "<w:body>" +
                            "<w:p>" +
                                        "<w:t>F_ck</w:t>" +
                                "<!-- -->" +
                                    "<w:t>F_ck</w:t>" +
                                "<!-- -->" +
                                                "<w:t>F_ck</w:t>" +
                            "</w:p>" +
                        "</w:body>" +
                    "</w:document>";
                XDocument doc = XDocument.Parse(xml);
                XElement document = (XElement)doc.FirstNode;
                XNamespace ns_w = document.GetNamespaceOfPrefix("w");
                List<XElement> ts = doc.Descendants(ns_w + "t").ToList();
                foreach (XElement t in ts)
                {
                    t.Value = "abc";
                }
            }
        }
    }
    ​
