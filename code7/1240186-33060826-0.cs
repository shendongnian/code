    //dt is DataTable
    foreach (var category in dt.AsEnumerable().GroupBy(g => g.Field<string>("Category")))
    {
    	var rows = category.OrderBy(o => o.Field<int>("Invoice")).ToArray();
    	foreach (DataRow row in rows.Where((w, i) => i != (rows.Length-1) / 2))
    	{
    		row["Category"] = "";
    	}
    }
