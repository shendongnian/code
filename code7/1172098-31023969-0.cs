    public IQueryable<ItemDTO> RepGetItems(string inOut, string planFact, int? year, int? month)
    {
        return GetItemsWithCategory().
            Where(i => i.InOut.Equals(inOut)).
            Where(i => i.PlanFact.Equals(planFact)).
            Where(i => !year.HasValue  || i.DateTime.Year.Equals(year.Value)).
            Where(i => !month.HasValue || i.DateTime.Month.Equals(month.Value));
    }
