     public IEnumerable<Book> GetBooks(DateTime startTime, DateTime endTime, string author, bool includeEnd)
        {
            var dateFilter = includeEnd ?
                // you have to do a little casting for the lambdas to know what type we're returning
                (Func<DateRangeQueryDescriptor<Book>, DateRangeQueryDescriptor<Book>>)
                (q => q.LessThanOrEquals(endTime))
                : q => q.LessThan(endTime);
            return elastic.Search<Book>(s => s
                .Index(IndexName)
                .Query(q => q.Term(book => book.Author, author) &&
                            q.DateRange(i =>
                            {
                                i = i.Field(book => book.Author)
                                .GreaterThanOrEquals(startTime);
                                return dateFilter(i);
                            }
                    )))
                    .Documents
                    .ToArray();
        }
