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
                string input =
                "<EnquirySingleItemResponse xmlns=\"http://tempuri.org/\">" +
                    "<EnquirySingleItemResult>" +
                    "<Response>" +
                      "<MSG>SUCCESS</MSG>" +
                      "<INFO>TESTING</INFO>" +
                    "</Response>   </EnquirySingleItemResult> </EnquirySingleItemResponse>";
                XDocument doc = XDocument.Parse(input);
                string msg = doc.Descendants().Where(x => x.Name.LocalName == "MSG").FirstOrDefault().Value;
                string info = doc.Descendants().Where(x => x.Name.LocalName == "INFO").FirstOrDefault().Value;
            }
        }
    }
    ​
