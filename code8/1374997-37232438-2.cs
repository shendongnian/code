     public IEnumerable<Book> GetBooksUsingExtension(DateTime startTime, DateTime endTime, string author, bool includeEnd)
        {
            return elastic.Search<Book>(s => s
               .Index(IndexName)
               .Query(q => q.Term(book => book.Author, author) &&
                           q.DateRange(i => i.Field(book => book.Author)
                               .GreaterThanOrEquals(startTime)
                               .LessThanWithOption(endTime, includeEnd)
                           )))
                   .Documents
                   .ToArray();
        }
