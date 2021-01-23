    private static IQueryable<T> FilterClassResultsOnId<T>(IQueryCriteria queryCriteria, IQueryable<T> queryResults) 
        where T : IViewType
    {
        if (!string.IsNullOrEmpty(queryCriteria.Id))
        {
            queryResults = from view in queryResults where view.Id == queryCriteria.Id select view;
        }
        return queryResults;
    }
