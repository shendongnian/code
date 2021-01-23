    public ActionResult Books(string title, string author)
    {
        var books = context.Book.AsQuerable();
        
        if (!String.IsNullOrWhiteSpace(title))
        {
            books = books.Where(m => m.Title == title);
        }
        if (!String.IsNullOrWhiteSpace(author))
        {
            books = books.Where(m => m.Author == author);
        }
        return View(books);
    }
