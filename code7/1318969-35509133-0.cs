        using AutoMapper.QueryableExtensions;
        ...
        public IQueryable<BookDTO> GetBooks()
        {
            return db.Books.ProjectTo<BookDTO>();
        }
