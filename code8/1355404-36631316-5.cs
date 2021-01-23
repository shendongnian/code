    public IEnumerable<PageTitle> GetPageTitlesForBook(BookContext dbContext, int bookId)
    {
        return dbContext
            .GetBooksAndPagesAndTitles()
            .SingleOrDefault(x => x.BookId == bookId)
            .Pages
            .Select(x => x.PageTitle);
    }
