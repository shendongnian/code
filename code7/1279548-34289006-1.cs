    public IEnumerable<ProductPeriod> GetFilteredProductPeriods
        (DateTime? from, DateTime? to, bool? includeActive, bool? includeInactive)
    {
        IQueryable<ProductPeriod> query = _entities.ProductPeriods;
        if (from != null)
        {
            query = query.Where(x => x.StartDate >= from.Value);
        }
        if (to != null)
        {
            query = query.Where(x => x.EndDate >= to.Value);
        }
        if (includeActive == false)
        {
            query = query.Where(x => !x.IsActive);
        }
        if (includeInactive == false)
        {
            query = query.Where(x => x.IsActive);
        }
        return query.ToList();
    }
