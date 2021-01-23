    var author = dbContext.Authors.Add(new Author()
    {
        AuthorId = Guid.NewGuid().ToString(),
        FullName = "Forexample"
    }).Entity;
    var page = dbContext.BookPages.Add(new BookPage()
    {
        BookPageId = Guid.NewGuid().ToString(),
        Number = 1
    }).Entity;
    var book = new Book.Book()
    {
        BookId = Guid.NewGuid().ToString(),
        Pages = new List<BookPage>(),
        Text = "new book"
    };
    book.Pages.Add(page);
    book.Author = author ;
    dbContext.Books.Add(book);
    dbContext.SaveChanges();
