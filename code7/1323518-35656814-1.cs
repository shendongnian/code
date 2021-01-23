    var grouped = from gTable in table.AsEnumerable()
                    group gTable by new { groupId = gTable["Column1"] } into groupby
                    select new
                    {
                        Value = groupby.Key,
                        ColumnValues = groupby
                    };
    foreach (var key in grouped)
    {
        pvar = "";
        foreach (var columnValue in key.ColumnValues)
        {
            pvar += columnValue["Column2"].ToString() + "|" + columnValue["Column3"].ToString();
        }
    }
