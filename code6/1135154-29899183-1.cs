    public IQueryable<T> SetDateCompare<T>(IQueryable<T> OriginalQuery, Func<T,DateTime> getDateFunc, DateTime ComparisonDate, bool isGreaterThan = true)
    where T : class
    {
        if (isGreaterThan)
        {
            OriginalQuery = OriginalQuery.Where(t => getDateFunc(t).Day >= ComparisonDate.Day)
                            .Where(t => getDateFunc(t).Month >= ComparisonDate.Month)
                            .Where(t => getDateFunc(t).Year >= ComparisonDate.Year);
        }
        else
        {
            OriginalQuery = OriginalQuery.Where(t => getDateFunc(t).Day <= ComparisonDate.Day)
                            .Where(t => getDateFunc(t).Month  <= ComparisonDate.Month)
                            .Where(t => getDateFunc(t).Year  <= ComparisonDate.Year);
    
        }
        return OriginalQuery;
    
    }
