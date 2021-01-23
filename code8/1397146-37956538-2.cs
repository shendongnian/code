      var resultsQuery = ArticleServerContext.Database.SqlQuery<ArticleSummary>("GetFullTextSearchResults @SearchTerm, @SkipRows, @TakeRows",
        new SqlParameter("@SearchTerm", fullTextQuery),
        new SqlParameter("@SkipRows", pagination.SkippedRows),
        new SqlParameter("@TakeRows", pagination.RowsPerPage));
    // Build model
    SearchResultsModel model = new SearchResultsModel
    {
        SearchTerm = searchTerm.Trim(),
        Pagination = pagination,
        Results = resultsQuery.ToList()   // <=== Here's where the error happens
    };
