    var results = doc.Descendants("book").Select(x => new BookModel() //note the syntax here
    {
        //Id = (string)x.Attribute("id"),
        Author = (string)x.Element("author"),
        Genre = (string)x.Element("genre"),
        Price = (decimal)x.Element("price"),
        PublishDate = (DateTime)x.Element("publish_date"),
        Description = (string)x.Element("description")
        //use the same exact properties as your BookModel
    }).ToList(); //ToList() may not be needed actually
    var model = new BookModel(); //And this is...?
