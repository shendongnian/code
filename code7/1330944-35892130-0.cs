    var dataExistsMap = table3.AsEnumerable()
    	.GroupBy(r => r["ColumnB"] as string)
    	.Where(g => !string.IsNullOrEmpty(g.Key))
    	.ToDictionary(g => g.Key, g => new HashSet<string>(
    		table2.Where(e => g.Any(r => !string.IsNullOrEmpty(r[e] as string)))
    	// Include the proper comparer if your IsEqual method is using non default string comparison
    	//, StringComparer.OrdinalIgnoreCase
    	)
    );
    
    foreach (DataRow entry1 in table1.Rows)
    {
    	var columnA = entry1["ColumnA"] as string;
    	if (string.IsNullOrEmpty(columnA)) continue;
    	HashSet<string> dataExistsSet;
    	if (!dataExistsMap.TryGetValue(columnA, out dataExistsSet)) continue;
    	foreach (string entry2 in table2.Where(dataExistsSet.Contains))
    		entry1[entry2] = Compute(columnA, entry2);
    }
