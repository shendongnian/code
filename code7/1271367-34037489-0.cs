    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication59
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml =
                    "<CustomizedFieldCollection>" +
                          "<CustomizedField>" +
                            "<Key>Documents Checked</Key>" +
                            "<DataType>Boolean</DataType>" +
                            "<Value>false</Value>" +
                          "</CustomizedField>" +
                          "<CustomizedField>" +
                            "<Key>Date Completed</Key>" +
                            "<DataType>DateTime</DataType>" +
                            "<Value></Value>" +
                          "</CustomizedField>" +
                    "</CustomizedFieldCollection>";
                XElement element = XElement.Parse(xml);
                XElement newField = new XElement("CustomizedField", new XElement[] {
                    new XElement("key", "Documents Checked"),
                    new XElement("DataType", "Boolean"),
                    new XElement("Value", "false")
                });
                element.Add(newField);
           }
        }
    }
