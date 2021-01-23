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
                    "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\" ?>" +
                    "<mgns1:PlaceXmlMessage xmlns:mgns1=\"http://www.testing.com/\">" +
                        "<mgns1:xmlDocument>" +
                            "<HubChangeRequest version=\"1.0\">" +
                                "<TransactionReference>" +
                                    "<AuthenticationID>TestSUPPLIERS</AuthenticationID>" +
                                    "<AuthenticationKey>hidden</AuthenticationKey>" +
                                    "<TransactionNumber>hidden</TransactionNumber>" +
                                "</TransactionReference>" +
                                "<MessageNumber>hidden</MessageNumber>" +
                                "<MessageCreatedDate>2016-03-01T12:31:31</MessageCreatedDate>" +
                                "<ReferenceNumber>ABC123456789</ReferenceNumber>" +
                                "<ProductDetails>" +
                                    "<StockItem LineReference=\"123456/1\">" +
                                        "<NewStatus>Despatched</NewStatus>" +
                                        "<DespatchReference>3 PARCEL LINE</DespatchReference>" +
                                    "</StockItem>" +
                                    "<StockItem LineReference=\"123345/2\">" +
                                        "<NewStatus>Despatched</NewStatus>" +
                                        "<DespatchReference>3 PARCEL LINE</DespatchReference>" +
                                    "</StockItem>" +
                                "</ProductDetails>" +
                            "</HubChangeRequest>" +
                        "</mgns1:xmlDocument>" +
                    "</mgns1:PlaceXmlMessage>";
                XDocument doc = XDocument.Parse(xml);
                XElement placeXmlMessage = (XElement)doc.FirstNode;
                XElement hubChangeRequest = doc.Descendants("HubChangeRequest").FirstOrDefault();
                placeXmlMessage.ReplaceWith(hubChangeRequest);
            }
        }
    }
