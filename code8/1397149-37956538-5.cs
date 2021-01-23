          var results = ArticleServerContext.Database.SqlQuery<ArticleSummary>("GetFullTextSearchResults @SearchTerm, @SkipRows, @TakeRows",
        new SqlParameter("@SearchTerm", fullTextQuery),
        new SqlParameter("@SkipRows", pagination.SkippedRows),
        new SqlParameter("@TakeRows", pagination.RowsPerPage)).ToList();
    // Build model
    SearchResultsModel model = new SearchResultsModel
    {
        SearchTerm = searchTerm.Trim(),
        Pagination = pagination,
        Results = results   // <=== Moved the call to ToList UP
    };
