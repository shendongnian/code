    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;
    using System.Text.RegularExpressions;
    namespace Calendar
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input =
                            "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\"?>" +
                "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ns0=\"http://domain.co.za/\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">" +
                  "<soapenv:Header>" +
                    "<ns0:username soapenv:actor=\"\">            </ns0:username>" +
                    "<ns0:password soapenv:actor=\"\">            </ns0:password>" +
                  "</soapenv:Header>" +
                  "<soapenv:Body>" +
                    "<ns0:PushMessage>" +
                      "<type>confirmation            </type>" +
                "<autoRelease>true            </autoRelease>" +
                      "<payload>" +
                        "<Confirmation>" +
                          "<MessageEnvelope>" +
                          "</MessageEnvelope>" +
                        "</Confirmation>" +
                      "</payload>" +
                    "</ns0:PushMessage>" +
                  "</soapenv:Body>" +
                "</soapenv:Envelope>";
                string pattern = "(</?)(\\w:)(\\w)";
                Regex expr = new Regex(pattern);
                input = expr.Replace(input, "$1$3");
                XDocument doc = XDocument.Parse(input);
            }
        }
    }
