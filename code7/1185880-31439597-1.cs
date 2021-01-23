    var result = doc.Descendants("Book")
                                .GroupBy(x=>x.Attribute("ISBN").Value)
                                .Select(b => new
                                {
                                    ISBN = b.Key,
                                    Genre = b.First().Attribute("Genre").Value,                                
                                    Buyer_Company = GetCompanyValue(b,"2","2"),
                                    Seller_Company = GetCompanyValue(b,"1","2"),
                                    Buyer_Broker = GetBrokerValue(b, "2"),
                                    Seller_Broker = GetBrokerValue(b, "1")
                                })
                                .ToArray();
