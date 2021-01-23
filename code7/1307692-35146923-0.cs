    XNamespace sNS = XNamespace.Get("http://schemas.xmlsoap.org/soap/envelope/");
    XNamespace wsseNS = XNamespace.Get("http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
    XNamespace xmlnsNS = XNamespace.Get("urn:us:gov:treasury:irs:ext:aca:air:7.0'");
    XNamespace ns10NS = XNamespace.Get("urn:us:gov:treasury:irs:msg:acauibusinessheader");
    XNamespace ns11NS = XNamespace.Get("http://www.w3.org/2000/09/xmldsig#");
    XNamespace ns12NS = XNamespace.Get("http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
    XNamespace ns13NS = XNamespace.Get("urn:us:gov:treasury:irs:msg:acasecurityheader");
    XNamespace ns2NS = XNamespace.Get("xmlns: ns2 = 'urn:us:gov:treasury:irs:common");
    XNamespace ns3NS = XNamespace.Get("urn:us:gov:treasury:irs:msg:form1094-1095Btransmitterupstreammessage");
    XNamespace ns4NS = XNamespace.Get("urn:us:gov:treasury:irs:msg:form1094-1095Ctransmitterupstreammessage");
    XNamespace ns5NS = XNamespace.Get("http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");
    XNamespace ns6NS = XNamespace.Get("urn:us:gov:treasury:irs:msg:form1094-1095BCtransmittermessage");
    XNamespace ns7NS = XNamespace.Get("urn:us:gov:treasury:irs:msg:form1094-1095BCtransmitterreqmessage");
    XNamespace ns8NS = XNamespace.Get("urn:us:gov:treasury:irs:msg:irsacabulkrequesttransmitter");
    XNamespace ns9NS = XNamespace.Get("urn:us:gov:treasury:irs:msg:acabusinessheader");
    XDocument xDoc = new XDocument(new XElement(sNS + "Envelope", new XAttribute(XNamespace.Xmlns + "S", sNS),
                            new XElement(sNS + "Header", new XAttribute(XNamespace.Xmlns + "wsse", wsseNS),
                                new XElement(ns13NS + "ACASecurityHeader", new XAttribute(XNamespace.Xmlns + "ns10", ns10NS),
                                    new XAttribute(XNamespace.Xmlns + "ns11", ns11NS),
                                    new XAttribute(XNamespace.Xmlns + "ns12", ns12NS),
                                    new XAttribute(XNamespace.Xmlns + "ns13", ns13NS),
                                    new XAttribute(XNamespace.Xmlns + "ns2", ns2NS),
                                    new XAttribute(XNamespace.Xmlns + "ns3", ns3NS),
                                    new XAttribute(XNamespace.Xmlns + "ns4", ns4NS),
                                    new XAttribute(XNamespace.Xmlns + "ns5", ns5NS),
                                    new XAttribute(XNamespace.Xmlns + "ns6", ns6NS),
                                    new XAttribute(XNamespace.Xmlns + "ns7", ns7NS),
                                    new XAttribute(XNamespace.Xmlns + "ns8", ns8NS),
                                    new XAttribute(XNamespace.Xmlns + "ns9", ns9NS),
                                    new XElement("Author", "Moreno, Jordao"),
                                    new XElement("Book",
                                        new XElement("Title", "Midieval Tools and Implement"),
                                        new XElement("Author", "Gazit, Inbar"))
                                    ),
                                new XComment("This is another comment")
                            ))
        );
