    private string BuildQueryString(List<string> keywords)
    {
        List<string> numbers = keywords.Where(keyword => keyword.All(Char.IsDigit))
                                       .ToList();
        List<string> words = keywords.Except(numbers)
                                     .Select(keyword => string.Format("('{0}')", keyword))
                                     .ToList();
        var queryBuilder = new StringBuilder();
        queryBuilder.AppendFormat(@"
            CREATE TABLE #Keywords
            (
                Keyword NVARCHAR(MAX)
            )
                                  
            INSERT INTO #Keywords (Keyword)
            VALUES {0}
            SELECT Title, Board, Class
            FROM Books
            WHERE Class IN ({1})
               OR EXISTS (SELECT TOP 1 1
                          FROM #Keywords
                          WHERE Title LIKE '%' + Keyword + '%'
                             OR Board LIKE '%' + Keyword + '%')",
            string.Join(", ", words), string.Join(", ", numbers));
        return queryBuilder.ToString();
    }
