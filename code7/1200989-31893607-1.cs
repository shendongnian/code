    private string BuildQueryString(List<string> keywords)
    {
        List<string> numbers = keywords.Where(keyword => keyword.All(Char.IsDigit))
                                       .ToList();
        List<string> words = keywords.Except(numbers)
                                     .Select(keyword => string.Format("('{0}')", keyword))
                                     .ToList();
        var queryBuilder = new StringBuilder();
        if (words.Count > 0)
        {
            queryBuilder.AppendFormat(@"
                CREATE TABLE #Keywords
                (
                    Keyword NVARCHAR(MAX)
                )
                                  
                INSERT INTO #Keywords (Keyword)
                VALUES {0} ",
                               
                string.Join(", ", words));
        }
        queryBuilder.AppendFormat(@"
            SELECT Title, Board, Class
            FROM Books ");
        string numbersFilter = string.Format("Class IN ({0})", string.Join(", ", numbers));
        string wordsFilter = @"EXISTS (SELECT TOP 1 1
                                       FROM #Keywords
                                       WHERE Title LIKE '%' + Keyword + '%'
                                          OR Board LIKE '%' + Keyword + '%')";
        if (numbers.Count > 0 && words.Count > 0)
        {
            queryBuilder.AppendFormat(@"
                WHERE {0} AND {1}", numbersFilter, wordsFilter);
        }
        else if (numbers.Count > 0)
        {
            queryBuilder.AppendFormat(@"
                WHERE {0}", numbersFilter);
        }
        else if (words.Count > 0)
        {
            queryBuilder.AppendFormat(@"
                WHERE {0}", wordsFilter);
        }
        return queryBuilder.ToString();
    }
