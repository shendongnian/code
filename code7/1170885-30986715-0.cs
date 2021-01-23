    private void WriteColumns(HttpResponseBase response)
    {
        var columnNames = columns
            .Select(lambda => {
                var expressionBody = lambda.Body;
                var memberExpression = (MemberExpression)expressionBody;
                var memberName = memberExpression.Member.Name;
                return memberName;
            })
           .ToList();
        foreach (var column in Columns)
            WriteCsvCell(response, column.ToString());
        response.Write(Environment.NewLine);
    }
