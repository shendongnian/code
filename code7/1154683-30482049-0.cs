    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication30
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input =
                    "<content>" +
                        "<reference>" +
                            "<title>www</title>" +
                            "<url>http://xxx</url>" +
                        "</reference>" +
                        "<reference>" +
                            "<title>yyy</title>" +
                            "<url>http://zzz</url>" +
                       "</reference>" +
                    "</content>";
                XDocument doc = XDocument.Parse(input);
                var results = doc.Descendants("reference")
                    .Select(x => new {
                        title = x.Descendants("title").FirstOrDefault().Value,
                        url = x.Descendants("url").FirstOrDefault().Value
                    });
            }
        }
    }
