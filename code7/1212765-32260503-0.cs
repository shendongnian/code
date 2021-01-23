    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication45
    {
        class Program
        {
            static void Main(string[] args)
            {
                string identification =
                   "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                   "<EN:eDWR" +
                      " xmlns:EN=\"urn:us:net:exchangenetwork\"" +
                      " xmlns:SDWIS=\"http://www.epa.gov/sdwis\"" +
                      " xmlns:ns3=\"http://www.epa.gov/xml\"" +
                      " xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"" +
                   "/>";
                XDocument doc = XDocument.Parse(identification);
                XElement eDWR = doc.Elements().Where(x => x.Name.LocalName == "eDWR").FirstOrDefault();
               XNamespace EN = eDWR.GetNamespaceOfPrefix("EN");
               XNamespace SDWIS = eDWR.GetNamespaceOfPrefix("SDWIS");
               XNamespace ns3 = eDWR.GetNamespaceOfPrefix("ns3");
               XNamespace xsi = eDWR.GetNamespaceOfPrefix("xsi");
               XElement submission = new XElement(EN + "Submission");
               submission.Add(new object[] {
                    new XAttribute(EN + "submissionFileCreatedDate", "2012-07-21"),
                    new XAttribute(EN + "submissionFileName", "B_14271BJB.csv"),
                    new XAttribute(EN + "submissionID", 1),
                });
               eDWR.Add(submission);
                
            }
        }
    }
