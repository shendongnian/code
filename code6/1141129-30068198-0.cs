    var temp = new DataTable();
    temp.Columns.Add("Name", typeof(string));
    temp.Columns.Add("Quantity", typeof(int));
    
    var query = dt.AsEnumerable()
        .GroupBy(row => row.Field<string>("Name"))
        .Select(g =>
        {
            var row = temp.NewRow();
            row.SetField("Name", g.Key);
            row.SetField("Quantity", g.Count());
            return row;
        }).CopyToDataTable();
