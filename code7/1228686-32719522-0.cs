    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                Output output = new Output()
                {
                    outputReportType = new List<OutputReportType>() {
                         new OutputReportType() {
                              outputReportTypeReportsReportItemsItem = new List<OutputReportTypeReportsReportItemsItem>() {
                                  new OutputReportTypeReportsReportItemsItem() {
                                       name = "Abc"
                                  }
                              }
                         }
                     }
                };
                XmlSerializer serializer = new XmlSerializer(typeof(Output));
                StreamWriter writer = new StreamWriter(FILENAME);
                serializer.Serialize(writer, output);
                writer.Flush();
                writer.Close();
                writer.Dispose();
            }
        }
        [XmlRoot("output")]
        public class Output
        {
            [XmlElement("OutputReportType")]
            public List<OutputReportType> outputReportType { get; set; }
        }
        [XmlRoot("OutputReportType")]
        public class OutputReportType 
        {
            [XmlElement("outputReportTypeReportsReportItemsItem")]
            public List<OutputReportTypeReportsReportItemsItem> outputReportTypeReportsReportItemsItem { get; set; }
        }
        
        [XmlRoot("OutputReportTypeReportsReportItemsItem")]
        public class OutputReportTypeReportsReportItemsItem 
        {
            [XmlElement("name")]
            public string name { get; set; }
        }
    }
    ​
