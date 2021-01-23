    public static IQueryable<Book> GetBooksAndPages(this BookContext db)
    {
        return db.Book.Include(x => x.Pages);
    }
    
    public static IQueryable<Book> GetBooksAndPagesAndTitles(this BookContext db)
    {
        return GetBooksAndPages(db).Include(p => p.PageTitle)
    
    }
