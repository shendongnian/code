    public IQueryable<ItemDTO> RepGetYearItems(string inOut, string planFact, int? year, int? month)
    {
        var query = GetItemsWithCategory().
            Where(i => i.InOut.Equals(inOut)).
            Where(i => i.PlanFact.Equals(planFact));
        if (year != null)
        {
            query = query.Where(i => i.DateTime.Year.Equals(year.Value));
        }
        if (month != null)
        {
            query = query.Where(i => i.DateTime.Month.Equals(month.Value));
        }
        return query;
    }
