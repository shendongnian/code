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
                    "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                    "<Dashboard CurrencyCulture=\"en-US\">" +
                        "<Title Text=\"Dashboard\" />" +
                        "<DataSources>" +
                        "<SqlDataSource ComponentName=\"dashboardSqlDataSource1\">" +
                            "<Name>Demo_Data_Excel</Name>" +
                            "<Connection Name=\"testdata\" ProviderKey=\"InMemorySetFull\">" +
                            "<Parameters>" +
                                "<Parameter Name=\"database\" Value=\"J:\\Demo\\Demo_Data_3.xml\" />" +
                                "<Parameter Name=\"read only\" Value=\"1\" />" +
                                "<Parameter Name=\"generateConnectionHelper\" Value=\"false\" />" +
                            "</Parameters>" +
                            "</Connection>" +
                            "<Query Type=\"TableQuery\" Name=\"Data\">" +
                            "<Table Name=\"Data\">" +
                                "<Column Name=\"Market Segment\" />" +
                                "<Column Name=\"Market Subsegmt\" />" +
                                "<Column Name=\"Customer\" />" +
                            "</Table>" +
                            "</Query>" +
                            "<ResultSchema>" +
                            "<DataSet Name=\"SQL Data Source 1\">" +
                                "<View Name=\"Data\">" +
                                "<Field Name=\"Market Segment\" Type=\"String\" />" +
                                "<Field Name=\"Market Subsegmt\" Type=\"String\" />" +          
                                "</View>" +
                            "</DataSet>" +
                            "</ResultSchema>" +
                        "</SqlDataSource>" +
                        "</DataSources>" +
                    "</Dashboard>";
                XDocument doc = XDocument.Parse(xml);
                XElement database = doc.Descendants("Parameter").Where(x => (string)x.Attribute("Name") == "database").FirstOrDefault();
                database.Attribute("Value").Value = "J:\\Demo\\Demo_Data_4.xml";
            }
        }
    }
