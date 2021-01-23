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
                List<int> myInts = new List<int>() { 1, 2, 3, 4, 5 };
                myInts.ForEach(x => x += 1);
                string input =
                    "<Root>" +
                        "<Orders>" +
                            "<Order>" +
                              "<CustomerID>GREAL</CustomerID>" +
                              "<EmployeeID>8</EmployeeID>" +
                              "<OrderDate>1997-07-04T00:00:00</OrderDate>" +
                              "<RequiredDate>1997-08-01T00:00:00</RequiredDate>" +
                              "<ShipInfo ShippedDate=\"1997-07-14T00:00:00\">" +
                                "<ShipVia>2</ShipVia>" +
                                "<Freight>4.42</Freight>" +
                                "<ShipName>Great Lakes Food Market</ShipName>" +
                                "<ShipAddress>2732 Baker Blvd.</ShipAddress>" +
                                "<ShipCity>Eugene</ShipCity>" +
                                "<ShipRegion>OR</ShipRegion>" +
                                "<ShipPostalCode>97403</ShipPostalCode>" +
                                "<ShipCountry>USA</ShipCountry>" +
                              "</ShipInfo>" +
                            "</Order>" +
                            "<Order>" +
                              "<CustomerID>GREAL</CustomerID>" +
                              "<EmployeeID>1</EmployeeID>" +
                              "<OrderDate>1997-07-31T00:00:00</OrderDate>" +
                              "<RequiredDate>1997-08-28T00:00:00</RequiredDate>" +
                              "<ShipInfo ShippedDate=\"1997-08-05T00:00:00\">" +
                                "<ShipVia>2</ShipVia>" +
                                "<Freight>116.53</Freight>" +
                                "<ShipName>Great Lakes Food Market</ShipName>" +
                                "<ShipAddress>2732 Baker Blvd.</ShipAddress>" +
                                "<ShipCity>Eugene</ShipCity>" +
                                "<ShipRegion>OR</ShipRegion>" +
                                "<ShipPostalCode>97403</ShipPostalCode>" +
                                "<ShipCountry>USA</ShipCountry>" +
                              "</ShipInfo>" +
                            "</Order>" +
                            "<Order>" +
                              "<CustomerID>GREAL</CustomerID>" +
                              "<EmployeeID>3</EmployeeID>" +
                              "<OrderDate>1997-09-25T00:00:00</OrderDate>" +
                              "<RequiredDate>1997-10-23T00:00:00</RequiredDate>" +
                              "<ShipInfo ShippedDate=\"1997-09-30T00:00:00\">" +
                                "<ShipVia>3</ShipVia>" +
                                "<Freight>76.13</Freight>" +
                                "<ShipName>Great Lakes Food Market</ShipName>" +
                                "<ShipAddress>2732 Baker Blvd.</ShipAddress>" +
                                "<ShipCity>Eugene</ShipCity>" +
                                "<ShipRegion>OR</ShipRegion>" +
                                "<ShipPostalCode>97403</ShipPostalCode>" +
                                "<ShipCountry>USA</ShipCountry>" +
                              "</ShipInfo>" +
                            "</Order>" +
                            "<Order>" +
                              "<CustomerID>GREAL</CustomerID>" +
                              "<EmployeeID>4</EmployeeID>" +
                              "<OrderDate>1998-01-06T00:00:00</OrderDate>" +
                              "<RequiredDate>1998-02-03T00:00:00</RequiredDate>" +
                              "<ShipInfo ShippedDate=\"1998-02-04T00:00:00\">" +
                                "<ShipVia>2</ShipVia>" +
                                "<Freight>719.78</Freight>" +
                                "<ShipName>Great Lakes Food Market</ShipName>" +
                                "<ShipAddress>2732 Baker Blvd.</ShipAddress>" +
                                "<ShipCity>Eugene</ShipCity>" +
                                "<ShipRegion>OR</ShipRegion>" +
                                "<ShipPostalCode>97403</ShipPostalCode>" +
                                "<ShipCountry>USA</ShipCountry>" +
                              "</ShipInfo>" +
                            "</Order>" +
                            "<Order>" +
                              "<CustomerID>GREAL</CustomerID>" +
                              "<EmployeeID>3</EmployeeID>" +
                              "<OrderDate>1998-04-07T00:00:00</OrderDate>" +
                              "<RequiredDate>1998-05-05T00:00:00</RequiredDate>" +
                              "<ShipInfo ShippedDate=\"1998-04-15T00:00:00\">" +
                                "<ShipVia>2</ShipVia>" +
                                "<Freight>25.19</Freight>" +
                                "<ShipName>Great Lakes Food Market</ShipName>" +
                                "<ShipAddress>2732 Baker Blvd.</ShipAddress>" +
                                "<ShipCity>Eugene</ShipCity>" +
                                "<ShipRegion>OR</ShipRegion>" +
                                "<ShipPostalCode>97403</ShipPostalCode>" +
                                "<ShipCountry>USA</ShipCountry>" +
                              "</ShipInfo>" +
                            "</Order>" +
                            "<Order>" +
                              "<CustomerID>GREAL</CustomerID>" +
                              "<EmployeeID>4</EmployeeID>" +
                              "<OrderDate>1998-04-22T00:00:00</OrderDate>" +
                              "<RequiredDate>1998-05-20T00:00:00</RequiredDate>" +
                              "<ShipInfo>" +
                                "<ShipVia>3</ShipVia>" +
                                "<Freight>18.84</Freight>" +
                                "<ShipName>Great Lakes Food Market</ShipName>" +
                                "<ShipAddress>2732 Baker Blvd.</ShipAddress>" +
                                "<ShipCity>Eugene</ShipCity>" +
                                "<ShipRegion>OR</ShipRegion>" +
                                "<ShipPostalCode>97403</ShipPostalCode>" +
                                "<ShipCountry>USA</ShipCountry>" +
                              "</ShipInfo>" +
                            "</Order>" +
                        "</Orders>" +
                    "</Root>";
                XDocument root = XDocument.Parse(input);
     
                var sortedOrder = root.Descendants("Order").OrderBy(x => (DateTime)x.Element("OrderDate")).ToList();
                XElement orders = root.Descendants("Orders").FirstOrDefault();
                orders.ReplaceWith(new XElement("Orders",sortedOrder));
                root.Save("filename");
      
            }
        }
    }
