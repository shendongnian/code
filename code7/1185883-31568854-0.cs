    const string xml =
        @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>    
        <Catalog>
        <Book ISBN=""1.1.1.1"" Genre=""Thriller"">
        <Title  Side=""1"">
        <Pty R=""1"" ID=""Seller_ID"">
            <Sub Typ=""26"" ID=""John"">
            </Sub>
        </Pty>
        <Pty R=""2"" ID=""ABC"">
        </Pty>
            </Title>
        </Book>
        <Book ISBN=""1.2.1.1"" Genre=""Thriller"">
        <Title  Side=""2"">
        <Pty R=""1"" ID=""Buyer_ID"">
            <Sub Typ=""26"" ID=""Brook"">
            </Sub>
        </Pty>
        <Pty R=""2"" ID=""XYZ"">
        </Pty>
            </Title>
        </Book>
        </Catalog>";
    var doc = XDocument.Parse(xml);
    var results = new List<object>();
    foreach (var book in doc.Descendants("Book")) {
        var title = book.Element("Title");
        string buyerCompany = null;
        string buyerBroker = null;
        string sellerCompany = null;
        string sellerBroker = null;
        if (title.Attribute("Side").Value == "1") {
            sellerCompany = title.Elements("Pty")
                .Where(pty => pty.Attribute("R").Value == "2")
                .Select(pty => pty.Attribute("ID").Value)
                .FirstOrDefault();
            sellerBroker = title.Elements("Pty")
                .Where(pty => pty.Attribute("R").Value == "1")
                .Select(pty => pty.Element("Sub").Attribute("ID").Value)
                .FirstOrDefault();
        } else if (title.Attribute("Side").Value == "2") {
            buyerCompany = title.Elements("Pty")
                .Where(pty => pty.Attribute("R").Value == "2")
                .Select(pty => pty.Attribute("ID").Value)
                .FirstOrDefault();
            buyerBroker = title.Elements("Pty")
                .Where(pty => pty.Attribute("R").Value == "1")
                .Select(pty => pty.Element("Sub").Attribute("ID").Value)
                .FirstOrDefault();
        }
        var result = new {
            ISBN = book.Attribute("ISBN").Value,
            Genre = book.Attribute("Genre").Value,
            Seller_Company = sellerCompany,
            Seller_Broker = sellerBroker,
            Buyer_Company = buyerCompany,
            Buyer_Broker = buyerBroker,
        };
        results.Add(result);
    }
