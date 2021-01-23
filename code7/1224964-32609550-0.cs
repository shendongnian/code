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
            const string savePath = @"C:\temp\test.xml";
            static void Main(string[] args)
            {
                string identification =
                    "<?xml version=\"1.0\" encoding=\"utf-8\" ?> " +
                    "<sh:StandardBusinessDocument" +
                       " xmlns:sh=\"http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader\"" +
                       " xmlns:eanucc=\"urn:ean.ucc:2\" " +
                       " xmlns:gdsn=\"urn:ean.ucc:gdsn:2\" " +
                       " xmlns:align=\"urn:ean.ucc:align:2\" " +
                       " xmlns:chemical_ingredient=\"urn:ean.ucc:align:chemical_ingredient:2\" " +
                       " xmlns:food_beverage_tobacco=\"urn:ean.ucc:align:food_beverage_tobacco:2\"" +
                       " xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
                       " xsi:schemaLocation=\"http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader http://www.gdsregistry.org/2.8/schemas/sbdh/StandardBusinessDocumentHeader.xsd" +
                       " urn:ean.ucc:2 http://www.gdsregistry.org/2.8/schemas/CatalogueItemNotificationProxy.xsd" +
                       " urn:ean.ucc:2 http://www.gdsregistry.org/2.8/schemas/AttributeValuePairExtensionProxy.xsd" +
                       " urn:ean.ucc:2 http://www.gdsregistry.org/2.8/schemas/CaseLevelNonGTINLogisticsUnitExtensionProxy.xsd" +
                       " urn:ean.ucc:2 http://www.gdsregistry.org/2.8/schemas/TradeItemExtensionSpecificsProxy.xsd" +
                       " urn:ean.ucc:2 http://www.gdsregistry.org/2.8/schemas/ChemicalIngredientExtensionProxy.xsd" +
                       " urn:ean.ucc:2 http://www.gdsregistry.org/2.8/schemas/FoodAndBeverageTradeItemExtensionProxy.xsd\"" +
                    "/>";
                
                XDocument doc = XDocument.Parse(identification);
                XElement standardBusinessDocument = doc.Root;
                XNamespace sh = standardBusinessDocument.Name.Namespace;
                standardBusinessDocument.Add(
                        new XElement(sh + "StandardBusinessDocumentHeader",
                        new XElement(sh + "HeaderVersion", "1,0"),
                        new XElement(sh + "Sender",
                            new XElement(sh + "Identifier", "5790000011032")),
                        new XElement(sh + "Receiver",
                        new XElement(sh + "Identifier", "5790000500000")),
                        new XElement(sh + "DocumentIdentification",
                        new XElement(sh + "Standard", "EAN.UCC"),
                        new XElement(sh + "TypeVersion", "2.8"),
                        new XElement(sh + "InstanceIdentifier", "DI-35346-34535-xt435345"),
                        new XElement(sh + "Type", "catalogueItemNotification"),
                        new XElement(sh + "CreationDateAndTime", "2013-12-20T10:46:26+00:00")
                    ))
                );
                doc.Save(savePath);
            }
        }
    }
    ​
