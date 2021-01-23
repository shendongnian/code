    public IQueryable<T> Apply<T>(IQueryable<T> source, 
        Expression<Func<T, DateTime>> dateField)
    {
        var result = source;
        if (BeginDate.HasValue)
        {
            if (BeginInclusive)
                result = result.Where(dateField.Compose(date => date >= BeginDate));
            else
                result = result.Where(dateField.Compose(date => date > BeginDate));
        }
        if (EndDate.HasValue)
        {
            if (EndInclusive)
                result = result.Where(dateField.Compose(date => date <= EndDate));
            else
                result = result.Where(dateField.Compose(date => date < EndDate));
        }
        return result;
    }
