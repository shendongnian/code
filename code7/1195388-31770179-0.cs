    `select new
    {
        Book = new { book.Id, book.Name},
        LibraryBook = new { libraryBook.Id, libraryBook.AnotherProperty},
        BookTag = new { bookTag.Name}
    }`
