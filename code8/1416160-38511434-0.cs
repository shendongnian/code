    IGrouping<TypeOfVi> group; // replace with actual type
    switch (grouping)
    {
        case "country":
            group = vi.GroupBy(v => v.User.CountryId);
            break;
        case "province":
            group = vi.GroupBy(v => v.User.ProvinceId);
            break;
        // and so on...
    }
    vix = group.Select(g => g.ToList()).ToList();
