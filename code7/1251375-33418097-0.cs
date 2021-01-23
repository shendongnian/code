    using System;
    using System.Xml;
    
    namespace XMLTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
                                <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
                                  <soap:Body>
                                    <GetITARListResponse xmlns=""http://tempuri.org/"">
                                      <GetITARListResult>
                                        <ClassificationCode>
                                          <code>dsd</code>
                                          <description>toto</description>
                                          <legislation>d</legislation>
                                        </ClassificationCode>
                                        <ClassificationCode>
                                          <code>dsd</code>
                                          <description>tata</description>
                                          <legislation>dsd</legislation>
                                        </ClassificationCode>
                                        <ClassificationCode>
                                          <code>code2</code>
                                          <description>dsds</description>
                                          <legislation>dsd</legislation>
                                        </ClassificationCode>
                                      </GetITARListResult>
                                    </GetITARListResponse>
                                  </soap:Body>
                                </soap:Envelope>";
    
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
    
                var items = doc.GetElementsByTagName("ClassificationCode");
    
                foreach (var item in items)
                {
                    Console.WriteLine(((System.Xml.XmlElement)(item)).InnerText.ToString());
                }
                Console.ReadLine();
            }
        }
    }
    // OUTPUT
    // dsdtotod
    // dsdtatadsd
    // code2dsdsdsd
