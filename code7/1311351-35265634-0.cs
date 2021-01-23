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
            const int NUMBER_OF_XML = 3;
            static void Main(string[] args)
            {
                string xml =
                    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                        "<feed version=\"0.3\" xmlns=\"http://purl.org/atom/ns#\">" +
                            "<title>Gmail - Inbox for xxxx@gmail.com</title>" +
                            "<tagline>New messages in your Gmail Inbox</tagline>" +
                            "<fullcount>1</fullcount>" +
                            "<link rel=\"alternate\" href=\"https://mail.google.com/mail\" type=\"text/html\" />" +
                            "<modified>2016-02-07T12:11:21Z</modified>" +
                            "<entry>" +
                                "<title>Access for less secure apps has been turned on</title>" +
                                "<summary>Access for less secure apps has been turned on Hi Buddy, You recently changed your security settings so</summary>" +
                                "<link rel=\"alternate\" href=\"https://mail.google.com/mail?account_id=agl.testauto@gmail.com&amp;message_id=152bb8ccd28d824b&amp;view=conv&amp;extsrc=atom\" type=\"text/html\" />" +
                                "<modified>2016-02-07T11:45:12Z</modified>" +
                                "<issued>2016-02-07T11:45:12Z</issued>" +
                                "<id>tag:gmail.google.com,2004:1525516088640373323</id>" +
                                "<author>" +
                                    "<name>Google</name>" +
                                    "<email>no-reply@accounts.google.com</email>" +
                                "</author>" +
                            "</entry>" +
                        "</feed>";
                XDocument doc = XDocument.Parse(xml);
                XElement firstNode = (XElement)doc.FirstNode;
                XNamespace ns = firstNode.Name.Namespace;
                var results = doc.Elements(ns + "feed").Select(x => new {
                        tagline = (string)x.Element(ns + "tagline"),
                        message_subject = (string)x.Element(ns + "entry").Element(ns + "title")
                    }).FirstOrDefault();
     
            }
        }
    }
