    var results = doc.Descendants("book").Select(x => new BookModel()
    {
        //Id = (string)x.Attribute("id"),
        Author = (string)x.Element("author"),
        Genre = (string)x.Element("genre"),
        Price = (decimal)x.Element("price"),
        PublishDate = (DateTime)x.Element("publish_date"),
        Description = (string)x.Element("description")
        //use the same exact properties as your model
    }).ToList();
