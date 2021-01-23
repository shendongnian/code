    var stores = books.SelectMany(x => x.Stores).GroupBy(x => new
    {
        x.Id,
        x.Name
    }).Select(x => new DestinationStore
    {
        Id = x.Key.Id,
        Name = x.Key.Name,
        Books = books.Where(bookFilter => bookFilter.Stores.Select(store => store.Id).Contains(x.Key.Id))
            .Select(book => new DestinationBook
            {
                Id = book.Id,
                Name = book.Name
            }).ToArray()
    });
