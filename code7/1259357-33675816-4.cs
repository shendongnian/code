    foreach (var list in listCollection)
    {
        var results = new DataTable();
        SPList spList = web.Lists.TryGetList(list);
        if (spList != null)
        {
            SPQuery qry = new SPQuery();
            qry.Query = "...";
            
            results.Merge(spList.GetItems(qry).GetDataTable());
        }
    }
    return results;
