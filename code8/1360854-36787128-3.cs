    using (ED.NWEntities ctx = new ED.NWEntities())
    {
        IQueryable<ED.User> Result = ctx.User.OrderBy(y => y.BirthDate)
                                        .DistinctBy(z => z.FirstName)
                                        .AsQueryable();
    }
