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
                var results = doc.Descendants().Where(x => x.Name.LocalName == "ofsTransactionProcessed").Select(x => new {
                    application = (string)x.Attribute("application"),
                    function = (string)x.Attribute("function"),
                    operation = (string)x.Attribute("operation"),
                    processingStatus = (string)x.Attribute("processingStatus"),
                    version = (string)x.Attribute("version"),
                    transactionId = x.Elements().Where(y => y.Name.LocalName == "transactionId").Select(z => (string)z).FirstOrDefault(),
                    fields = x.Elements().Where(y => y.Name.LocalName == "field").Select(z => new {
                        mv = (string)z.Attribute("mv"),
                        name = (string)z.Attribute("name"),
                        sv = (string)z.Attribute("sv"),
                        value = (string)z
                    }).ToList()
                }).FirstOrDefault();
            }
        }
    }
