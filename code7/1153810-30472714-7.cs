    public IEnumerable<PieModel> getTypesForStatistics()
    {
        var dbo = new UsersContext();
        var all = (from a in dbo.Note
                          select a).ToList();
        var results = all.GroupBy(item => item.language.lang)
                             .Select(g => new PieModel
                             {
                                 Language = g.Key,
                                 Count = g.Count()
                             });
        return results.ToList();
    }
