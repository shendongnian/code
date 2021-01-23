    using (var bookContext = new BookContext())
    {
      var firstUserWithAllRelatedBooks = bookContext.Users
        .Include(u => u.Books)
        .First();
    }
