    DataTable table = new DataTable();
    table.Columns.Add("C1");
    table.Columns.Add("C2", typeof(string), "TRIM(C1)");
    table.Rows.Add(" 1  ");
    table.Rows.Add("   1");
    table.Rows.Add("2 ");
    table.Rows.Add(" 2");
    table.Rows.Add("3");
    DataTable temp = new DataView(table).ToTable(true, "C2");
    List<string> items = new List<string>();
    foreach (DataRow row in temp.Rows)
    {
        items.Add(row["C2"].ToString());
    }
