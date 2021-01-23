    const string xml = 
        @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>    
        <Catalog>
            <Book ISBN=""1.1.1.1"" Genre=""Thriller"">
                <Title  Side=""1"" MMY=""000"">
                    <Pty R=""1"" ID=""Seller_ID"">
                        <Sub Typ=""26"" ID=""Seller_Broker"">
                        </Sub>
                    </Pty>
                    <Pty R=""2"" ID=""Seller_Company"">
                    </Pty>
                </Title>
            </Book>
            <Book ISBN=""1.1.1.1"" Genre=""Thriller"">
                <Title  Side=""2"">
                    <Pty R=""1"" ID=""Buyer_ID"">
                        <Sub Typ=""26"" ID=""Buyer_Broker"">
                        </Sub>
                    </Pty>
                    <Pty R=""2"" ID=""Buyer_Company"">
                    </Pty>
                </Title>
            </Book>
        </Catalog>";
    var doc = XDocument.Parse(xml);
    var results = doc.Descendants("Book")
        .GroupBy(x => x.Attribute("ISBN").Value)
        .Select(x => new {
            ISBN = x.Key,
            Genre = x.First().Attribute("Genre").Value,
            PublishDate = x.First().Element("Title").Attribute("MMY").Value,
            BuyerId = x.Where(book => book.Element("Title").Attribute("Side").Value == "2")
                .First()
                .Element("Title")
                .Element("Pty")
                .Attribute("ID").Value
        })
        .ToArray();
