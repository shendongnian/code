    using (var session = DocumentStoreHolder.Store.OpenSession())
    {
        var books = session.Query<Book>().ToList();
        books.ForEach(book =>
        {
             //Note that book is an object, write out one of it's properties
             Console.WriteLine(book.Name); 
        });
    }
