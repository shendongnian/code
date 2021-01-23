    XDocument doc = /* load your XML to XDocument */
    XNamespace gbResponse = "demo.com/test/DeclarationGbResponse";
    XNamespace gbIdentityType = "demo.org.uk/DeclarationGbIdentityType";
    XNamespace gbAcceptanceRespons = "demo.org.uk/test/DeclarationGbAcceptanceResponse";
    XNamespace gbItemResponse = "demo.org.uk/test/DeclarationGbItemResponse";
    XNamespace monetaryType = "demo.org.uk/test/MonetaryType";
    var declarationUcr = (string)doc.Root
    								.Element(gbResponse + "declarationIdentity")
    								.Element(gbIdentityType + "declarationUcr");
    var ICS = (string)doc.Root
    					 .Element(gbResponse + "acceptanceResponse")
    					 .Element(gbAcceptanceRespons + "ICS");
    var value = (string)doc.Root
    					   .Element(gbResponse + "acceptanceResponse")
    					   .Element(gbAcceptanceRespons + "itemResponses")
    					   .Element(gbAcceptanceRespons + "itemResponse")
    					   .Element(gbItemResponse + "statisticalValue")
    					   .Element(monetaryType + "value");
    Console.WriteLine(declarationUcr);
    Console.WriteLine(ICS);
    Console.WriteLine(value);
