    public IEnumerable<BaseClass> getRawDataDb(DependencySheet sheet, string name)
    {
        //type declaration OpenInventory must be located at the same assembly with getRawDataDb
        var type = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.Name == name).First();
        var res = new List<BaseClass>();
        var source = sqlQuery.Database.SqlQuery(type, sheet.Query);
        foreach (var item in source)
            res.Add(item as BaseClass);
        return res;
    }
