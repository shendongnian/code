    using (MyAppContext c = new MyAppContext())
    {
        foreach (DbValues dbValues in c.DbValues.Where(a=> a.Timestamp < dateParsed))
        {
            ...
        }
    }
