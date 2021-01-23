    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication37
    {
        class Program
        {
            const string FILENAME = @"\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var results = doc.Descendants().Where(x => x.Name.LocalName == "myFields").Select(y => new
                {
                    instrumentTag = y.Elements().Where(z => z.Name.LocalName == "InstrumentTag").FirstOrDefault().Value,
                    issueDate = y.Elements().Where(z => z.Name.LocalName == "IssueDate").FirstOrDefault().Value,
                    listName = y.Elements().Where(z => z.Name.LocalName == "listName").FirstOrDefault().Value,
                    strFormName = y.Elements().Where(z => z.Name.LocalName == "strFormName").FirstOrDefault().Value,
                    Attachments = y.Elements().Where(z => z.Name.LocalName == "Attachments").Select(a => new {
                       attachment = a.Elements().Where(b => b.Name.LocalName == "Attachment").Select(c => c.Value).FirstOrDefault()
                    }).ToList(),
                }).ToList();
            }
        }
    }
