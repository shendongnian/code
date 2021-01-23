    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication61
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml =
                    "<ApplicationExtraction>" +
                        "<ApplicationDate>10/06/2015</ApplicationDate>" +
                        "<Status>Application Received</Status>" +
                        "<EquipmentType>Equipment</EquipmentType>" +
                        "<GetActiveLeaseApplicationParties>" +
                            "<Item>" +
                                "<RelationshipType>Primary Lessee</RelationshipType>" +
                                "<PartyNumber>20000107</PartyNumber>" +
                                "<FirstName>Parvesh</FirstName>" +
                                "<LastName>Musharuf</LastName>" +
                                "<DateOfBirth>12/12/1993</DateOfBirth>" +
                                "<CreationDate>10/06/2015</CreationDate>" +
                            "</Item>" +
                            "<Item>" +
                                "<RelationshipType>Co-Lessee</RelationshipType>" +
                                "<PartyNumber>20000108</PartyNumber>" +
                                "<IsCorporate>No</IsCorporate>" +
                                "<FirstName>Pary</FirstName>" +
                                "<LastName>Mushroom</LastName>" +
                                "<DateOfBirth>1/12/1953</DateOfBirth>" +
                                "<CreationDate>10/06/2015</CreationDate>" +
                            "</Item>" +
                        "</GetActiveLeaseApplicationParties>" +
                    "</ApplicationExtraction>";
                XDocument doc = XDocument.Parse(xml);
                Dictionary<int, Item> dict = new Dictionary<int, Item>();
                foreach (XElement item in doc.Descendants("Item").AsEnumerable())
                {
                    Item newItem = new Item() {
                        relationshipType = item.Element("RelationshipType").Value,
                        partyNumber = int.Parse(item.Element("PartyNumber").Value),
                        isCorporate = item.Element("IsCorporate") == null ? false :
                           item.Element("IsCorporate").Value  == "Yes" ? true : false,
                        firstName = item.Element("FirstName").Value,
                        lastName = item.Element("LastName").Value,
                        dateOfBirth = DateTime.Parse(item.Element("DateOfBirth").Value),
                        creationDate = DateTime.Parse(item.Element("CreationDate").Value)
                    };
                    dict.Add(newItem.partNumber, newItem);
                }
            }
            public class Item
            {
                public string relationshipType { get; set; }
                public int partyNumber { get; set; }
                public Boolean isCorporate { get; set; }
                public string firstName { get; set; }
                public string lastName { get; set; }
                public DateTime  dateOfBirth { get; set; }
                public DateTime creationDate { get; set; }
            }
        }
     
    }
