    var grouped = from table in table.AsEnumerable()
                    group table by new { groupId = table["Column1"] } into groupby
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
