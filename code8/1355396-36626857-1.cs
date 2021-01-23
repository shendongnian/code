    // pass the book you want in as a parameter, viewbag, etc.
    using (var dbContext = new BookContext())
    {
        var bookPages = dbContext.BookPages
            .Where(p => p.Book.BookId == myBookId)
            .Select(p => new { 
                Bookid = p.Book.BookId,
                Text = p.Book.Text,
                PageNumber = p.Number,
                PageTitle = p.PageTitle.Title
            });
    }
