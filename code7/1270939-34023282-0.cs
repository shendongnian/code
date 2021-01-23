    public IEnumerable<Table1> GetThingsFromDatabse(DataContext db, IList<MyObject> objects)
    {
        var ids = objects.Select(x => x.Id).ToList();
        var results = Enumerable.ToList(
            from x in db.Table1s
            where ids.Contains(x.Id)
            select x
        );
        return results;
    }
