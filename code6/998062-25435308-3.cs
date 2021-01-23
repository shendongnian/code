    var quotes = XDocument.Load("Quotes.xml")
                          .Descendants("Quote")
                          .Select(x => new Quote {
                                     Content = (string) x.Attribute("Content"),
                                     Category = (string) x.Attribute("Category")
                                  })
                          .Where(q => q.Category != "Junk")
                          .ToList();
    cat.Text = quotes.First().Content;
