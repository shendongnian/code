            //Licence verification:
            var accessXML = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("AccessRequest",
                    new XAttribute(XNamespace.Xml + "lang", "en"),
                    new XElement("AccessLicenseNumber", "LICENCE"),
                    new XElement("UserId", "USERID"),
                    new XElement("Password", "PASSWORD")));
            //Shipping request:
            var serviceXML = new XDocument(    
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("RatingServiceSelectionRequest",
                new XAttribute(XNamespace.Xml + "lang", "en"),
                new XElement("Request",
                    new XElement("TransactionReference",
                        new XElement("CustomerContext", "Rating and Service"),
                        new XElement("XpciVersion", "1.0001")),
                    new XElement("RequestAction", "Rate"),
                    new XElement("RequestOption", "Rate")),
            
                    new XElement("PickupType",
                        new XElement("Code", "01"),
                        new XElement("Description", "Daily Pickup")),
                    new XElement("Shipment",
                        new XElement("Shipper",
                            new XElement("Address",
                                new XElement("PostalCode", "33706"),
                                new XElement("CountryCode", "US"))),
                        new XElement("ShipTo",
                            new XElement("Address",
                                new XElement("PostalCode", "34221"), //GET from postObject
                                new XElement("CountryCode", "US"))), //GET from postObject
                        new XElement("ShipFrom",
                            new XElement("Address",
                                new XElement("PostalCode", "33706"),
                                new XElement("CountryCode", "US"))),
                        new XElement("Service",
                            new XElement("Code", "03")), //GET from postObject
                        new XElement("Package",
                            new XElement("PackagingType",
                                new XElement("Code", "02")),
                            new XElement("Dimensions",
                                new XElement("UnitOfMeasurement",
                                    new XElement("Code", "IN")),
                                new XElement("Length", "20"),
                                new XElement("Width", "20"),
                                new XElement("Height", "20")),
                            new XElement("PackageWeight",
                                new XElement("UnitOfMeasurement",
                                    new XElement("Code", "LBS")),
                                new XElement("Weight", "10")))))); //GET from postObject
            //Combine the strings and POST
            var requestXml = accessXML.ToString() + serviceXML.ToString();
