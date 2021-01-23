    var result = from book in doc.Descendants("Book")
                    select new
                    {
                        ISBN = (string)book.Attribute("ISBN"),
                        Genre = (string)book.Attribute("Genre"),
                        PublishDate = (DateTime)book.Elements("Title")
                            .Select(e => e.Attribute("PublishDt"))
                            .Single(),
                        Buyer = (string)book.Descendants("Pty")
                            .Where(e => (int)e.Attribute("R") == 1)
                            .Select(e => e.Attribute("ID"))
                            .Single(),
                        Seller = (string)book.Descendants("Pty")
                            .Where(e => (int)e.Attribute("R") == 2)
                            .Select(e => e.Attribute("ID"))
                            .Single()
                    };
