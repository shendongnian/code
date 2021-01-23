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
                    "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
                    "<GetReturnFileResponse xmlns=\"http://tempuri.org/\">" +
                      "<GetReturnFileResult xmlns:a=\"http://schemas.datacontract.org/2004/07/SigmaAPIService\" xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\">" +
                        "<a:FileContent>/*Byte[] data type long string looks like 'IkRWTEoxMDI2LkVGQiIsIkVGVCIsIjgxOCIsIlZBTlNQRVlCUk9FQ0siLCIxMC8yNi8xNSIsIjA3Mzk3MjE4MSIsIjcwMDA3ODc5MDY5MDUwJSMDEiLCIxMC8yOC8xNSIsIlBCIiLCIiDQo=' here. **removed some chars just a sample*/</a:FileContent>" +
                        "<a:Response>" +
                          "<a:ResponseCode>1</a:ResponseCode>" +
                          "<a:ResponseMessage>Successfully processed</a:ResponseMessage>" +
                          "<a:ResponseType>Success</a:ResponseType>" +
                        "</a:Response>" +
                      "</GetReturnFileResult>" +
                    "</GetReturnFileResponse>";
                XDocument doc = XDocument.Parse(xml);
                XElement fileContent = doc.Descendants().Where(x => x.Name.LocalName == "FileContent").FirstOrDefault();
                XNamespace ns_a = fileContent.Name.Namespace;
            }
        }
    }
    ​
