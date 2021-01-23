    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml =
                  "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                    "<n1:Form109495CTransmittalUpstream" +
                        " xmlns=\"urn:us:gov:treasury:irs:ext:aca:air:6.2\" xmlns:irs=\"urn:us:gov:treasury:irs:common\"" +
                        " xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"" +
                        " xmlns:n1=\"urn:us:gov:treasury:irs:msg:form1094-1095Ctransmitterupstreammessage\"" +
                        " xsi:schemaLocation=\"urn:us:gov:treasury:irs:msg:form1094-1095Ctransmitterupstreammessage IRS-Form1094-1095CTransmitterUpstreamMessage.xsd\">" +
                    "</n1:Form109495CTransmittalUpstream>";
                XDocument doc = XDocument.Parse(xml);
                XElement form109495CTransmittalUpstream = (XElement)doc.FirstNode;
                XNamespace  def = form109495CTransmittalUpstream.GetDefaultNamespace();
                XNamespace irs = form109495CTransmittalUpstream.GetNamespaceOfPrefix("irs");
                XNamespace n1 = form109495CTransmittalUpstream.GetNamespaceOfPrefix("n1");
                XElement form1094CUpstreamDetail = new XElement(def + "Form1094CUpstreamDetail", new XAttribute[] {
                    new XAttribute("recordType", "String"), new XAttribute("lineNum", 0)
                });
                form109495CTransmittalUpstream.Add(form1094CUpstreamDetail);
                form109495CTransmittalUpstream.Add(new XElement("SubmissionId", 1));
                form109495CTransmittalUpstream.Add(new XElement(irs + "TaxYr", 1000));
                form109495CTransmittalUpstream.Add(new XElement(irs + "CorrectedInd", true));
            }
        }
    }
    ​
