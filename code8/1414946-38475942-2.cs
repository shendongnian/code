    var oldIdLookup = oldResults.AsEnumerable().ToLookup(r => r.Field<int>("ID"));
    DataTable final = newResults.Clone();
    foreach (DataRow row in newResults.Rows)
    {
        int id = row.Field<int>("ID");
        int level = row.Field<int>("Level");
        int count = oldIdLookup[id].Count(); // change logic if desired
        int newLevel = level + count;        // change logic if desired
        final.Rows.Add(id, row.Field<string>("Name"), newLevel);
    }
    
