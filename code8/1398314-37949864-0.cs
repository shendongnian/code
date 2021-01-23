    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication102
    {
        class Program
        {
            
            static void Main(string[] args)
            {
                string responseXml =
                    "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                    "<Envelope" +
                        " xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\"" +
                        " xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"" +
                        " xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">" +
                        "<soap:Body>" +
                            "<LoginResponse" +
                                " xmlns=\"http://schemas.microsoft.com/sharepoint/soap/\">" +
                                "<LoginResult>" +
                                    "<CookieName>FedAuth</CookieName>" +
                                    "<ErrorCode>NoError</ErrorCode>" +
                                    "<TimeoutSeconds>1800</TimeoutSeconds>" +
                                "</LoginResult>" +
                            "</LoginResponse>" +
                        "</soap:Body>" +
                    "</Envelope>";
                XDocument xml = XDocument.Parse(responseXml);
                var soapResponse = xml.Descendants().Where(x => x.Name.LocalName == "LoginResult").Select(x => new SoapResponse()
                {
                    CookieName = (string)x.Element(x.Name.Namespace + "CookieName"),
                    TimeoutSeconds = (int)x.Element(x.Name.Namespace + "TimeoutSeconds"),
                    ErrorCode = (string)x.Element(x.Name.Namespace + "ErrorCode")
                }).FirstOrDefault();
            }
     
        }
            public class SoapResponse
            {
                public string CookieName { get; set;}
                public int TimeoutSeconds { get; set;}
                public string ErrorCode { get; set;}
            }
     
     
    }
