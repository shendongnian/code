    var dt = new DataTable();
    var dc = new DataColumn() { ColumnName = "ID", DataType = typeof(string) };
    dt.Columns.Add(dc);
    dc = new DataColumn() { ColumnName = "Name", DataType = typeof(string) };
    dt.Columns.Add(dc);
    dt.Rows.Add(new object[] { "2", "A" });
    dt.Rows.Add(new object[] { "4", "B" });
    dt.Rows.Add(new object[] { "3", "C" });
    dt.Rows.Add(new object[] { "5", "D" });
    dt.Rows.Add(new object[] { "1", "E" });
    List<string> order = new List<string>() { "1", "3", "2", "5", "4" };
    var query = from item in order
                join row in dt.AsEnumerable() on item equals row.Field<string>("ID")
                select row;
    var result = query.CopyToDataTable();
