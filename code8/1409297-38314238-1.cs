    //Returns a filtered dataset based on provided search filters
    //searchFilters is an object T which contains the search filters entered.
    private List<T> GetSearchResults(T searchFilters, string sortDir = "ASC", int pageSize, int currentPage)
    {
        IQueryable<T> searchResults = context.GetCollection(); //get your data context here
        var filterExpressions = new List<Expression<Func<T, bool>>>();
        //Add filters
        foreach (var field in Fields)
        {
            //try to get the search value, ignoring null exceptions because it's much harder
            //to check for null objects at multiple levels. Instead the exception tells us there's
            //no search value
            string searchValue = null;
            try 
            {
                searchValue = field.GetValue(searchFilters)?.ToString(); 
            }
            catch (NullReferenceException) { }
            if (string.IsNullOrWhiteSpace(searchValue)) continue;
            //shared expression setup
            ParameterExpression param = field.FieldExpression.Parameters.First();
            Expression left = field.FieldExpression.Body;
            ConstantExpression right = Expression.Constant(searchValue);
            Expression body = null;
            //create expression for strings so we can use "contains" instead of "equals"           
            if (field.FieldType == typeof(string))
            {
                //build the expression body
                MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });                    
                body = Expression.Call(left, method, right);
            }
            else
            {   //handle expression for all other types      
                body = Expression.Equal(left, right);
            }
            //finish expression
            Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(body, param);
            filterExpressions.Add(lambda);
        }
        //apply the expressions
        searchResults = filterExpressions.Aggregate(searchResults, (current, expression) => current.Where(expression));
        //get sort field
        Field<T> sortField = Fields.FirstOrDefault(f => f.SortField);
        searchResults = searchResults.OrderBy($"{sortField.UnqualifiedFieldName} {sortDir}");                                                                         
        // Get the search results
        int count = searchResults.Count();
        int maxPage = count / pageSize;
        if (maxPage * pageSize < count) maxPage++;
        if (currentPage > maxPage) currentPage = maxPage;
        int skip = Math.Max(0, (filters.page - 1) * pageSize);
        int display = Math.Max(0, Math.Min(count - skip, pageSize));
        return searchResults.Skip(skip).Take(display).ToList();
    }     
