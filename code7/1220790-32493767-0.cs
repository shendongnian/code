    static class DaoExtensions 
    {
      public static IQueryable<BookEx> BookPlusAuthorNames(this DbContext context) 
      {
        var query = from t in context.Books
          join t1 in context.Authors on t.Id equals t1.AuthorId
          select new BookEx {
             Id = t.Id,
             Name = t.Name,
             AuthorId = t.AuthorId,
             AuthorName = t1.Name
          }
        return query;
      }        
    }
