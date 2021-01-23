    var oldIdLookup = oldResults.AsEnumerable().ToLookup(r => r.Field<int>("ID"));
    DataTable final = newResults.Clone();
    foreach (DataRow row in newResults.Rows)
    {
        int id = row.Field<int>("ID");
        int level = row.Field<int>("Level");
        int oldLevel = oldIdLookup[id].Sum(r => r.Field<int>("Level")); // change logic if desired(f.e. Max instead of Sum)
        int newLevel = oldLevel + level; // change logic if desired
        final.Rows.Add(id, row.Field<string>("Name"), newLevel);
    }
    
