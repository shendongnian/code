    var result = doc.Descendants("Book")
                    .Select(b =>
                       {
                           var buyerNode = b.Element("Title").Elements("Pty")
                                               .First(x => x.Attribute("R").Value == "1");
                           var sellerNode = b.Element("Title").Elements("Pty")
                                                .First(x => x.Attribute("R").Value == "2");
                          return new
                             {
                                ISBN = b.Attribute("ISBN").Value,
                                Genre = b.Attribute("Genre").Value,
                                PublishDate = b.Element("Title").Attribute("PublishDt").Value,
                                Buy = buyerNode.Attribute("ID").Value,
                                Sell = sellerNode.Attribute("ID").Value,
                             };
                        }
                       ).ToArray();
