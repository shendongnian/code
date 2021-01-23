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
                string definition =
                    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                    "<Ontology xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"" +
                        " xsi:schemaLocation=\"http://www.w3.org/2002/07/owl# http://www.w3.org/2009/09/owl2-xml.xsd\"" +
                        " xmlns=\"http://www.w3.org/2002/07/owl#\"" +
                        " xml:base=\"http://example.com/myOntology\"" +
                        " ontologyIRI=\"http://example.com/myOntology\">" +
                    "</Ontology>";
                XDocument doc = XDocument.Parse(definition);
                XElement ontology = (XElement)doc.FirstNode;
                XNamespace ns = ontology.Name.Namespace;
                ontology.Add(new XElement[] {
                    new XElement(ns + "Prefix", new XAttribute[] {
                           new XAttribute("name", "myOnt"),
                           new XAttribute("IRI", "http://example.com/myOntology#")
                    }),
                    new XElement(ns + "Import", "http://example.com/someOtherOntology")
                });
            }
        }
    }
    ​
