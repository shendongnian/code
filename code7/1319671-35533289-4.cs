    public IQueryable<T> GetCaseCommonData<T>()
        where T : Case
    {
        return context.Cases.OfType<T>
            .Include(p => p.Owner)
            .Include(p => p.CreatedBy)
            .Include(p => p.ModifiedBy)
            .Include(p => p.LinkedObjects);
    }
