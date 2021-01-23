    // Create IQueryable
    var query = from a in ArticleServerContext.Set<Article>()
                where a.Approved
                orderby a.UtcDate descending
                select new { a, Total = ArticleServerContext.Set<Article>().Where(x => x.Approved).Count() };
    
    //Get raw rows for current page with Total(Count) field
    var result = query.Skip((CurrentPage - 1) * RowsPerPage).Take(RowsPerPage).ToList();
    
    //this data you actually will use with your logic 
    var actualData = result.Select(x => x.a).ToList();
    
    // Get total rows (needed for pagination logic)
    int totalRows = result.First().Total;
