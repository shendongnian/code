    public IQueryable<ItemDTO> RepGetYearItems(string inOut, string planFact, int monthyear, bool useMonth)
    {
        var query = GetItemsWithCategory().
            Where(i => i.InOut.Equals(inOut)).
            Where(i => i.PlanFact.Equals(planFact));
        if (useMonth)
        {
            query = query.Where(i => i.DateTime.Month.Equals(monthyear));
        }
        else
        {
            query = query.Where(i => i.DateTime.Year.Equals(monthyear));
        }
        return query;
    }
