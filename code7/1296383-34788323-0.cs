    using (var uow = new UnitOfWork())
    {
        // all database interactions happen inside of here
        var book = new Book();
        // set a bunch of properties, etc.
        uow.BookRepository.Add(book);
        uow.ShelfRepository.Add(someShelf);
        // and so on...
        uow.Commit();
    }
