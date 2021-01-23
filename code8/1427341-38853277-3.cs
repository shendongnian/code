    using (var sw = new StringWriter())
    {
        using (var xw = new XmlTextWriter(sw))
        {
            var book = new Book();
            book.Author = new Author { AuthorName = "Bob" };
            book.Category = new Category { CategoryId = 5 };
            book.Publisher = new Publisher { City = "Clearwater" };
            var serializer = new DataContractSerializer(typeof(Book));
            serializer.WriteObject(xw, book);
            var output = sw.ToString();
            Assert.IsNotNull(sw);
        }
    }
