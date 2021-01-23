    var articlesById = articles
       .GroupBy(article => article.Id)
       .Select(g => new { Article = g.First(), Count = g.Count() });
    XDocument receipt = new XDocument(
        new XDeclaration("1.0", "utf-8", null),
        new XElement("FiscalRecipet",
            articlesById.Select(x => new XElement("FiscalItem",
                new XElement("Name", x.Article.Name),
                new XElement("Price", x.Article.Price),
                new XElement("Quantity", x.Count),
                new XElement("TaxGroup", x.Article.TaxGroup))
        )
    );
