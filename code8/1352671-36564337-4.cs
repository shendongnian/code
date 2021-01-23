    using (var dbContext = new BookContext())
    {
        var author = dbContext.Authors.Add(new Author()
        {
            FullName = "Forexample"
        }).Entity;
        var page = dbContext.BookPages.Add(new BookPage()
        {
            Number = 1
        }).Entity;
                
        var book = new Book.Book()
        {
            Text = "new book"
        };
        book.Pages.Add(page);
        book.Author = author;
        dbContext.Books.Add(book);
        dbContext.SaveChanges();
    }
