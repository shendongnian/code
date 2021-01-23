    using System;
    using System.IO;
    using System.Net;
    using System.Web.Services.Description;
    using System.Text;
    using System.Xml.Schema;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                //Build the URL request string
                UriBuilder uriBuilder = new UriBuilder(@"http://myservice.local/xmlbooking.asmx");
                uriBuilder.Query = "WSDL";
    
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uriBuilder.Uri);
                webRequest.ContentType = "text/xml;charset=\"utf-8\"";
                webRequest.Method = "GET";
                webRequest.Accept = "text/xml";
    
                //Submit a web request to get the web service's WSDL
                ServiceDescription serviceDescription;
                using (WebResponse response = webRequest.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        serviceDescription = ServiceDescription.Read(stream);
                    }
                }
    
                Types types = serviceDescription.Types;
                XmlSchema xmlSchema = types.Schemas[0];
                
                // Client implementation omitted for clarity sake.
                var client = some client here;
                
                var validation = new XsdValidationBehavior(new XmlSchemaSet { xmlSchema });
                
                client.ChannelFactory.Behaviours.Add(validation);
                
            }
        }
    }
