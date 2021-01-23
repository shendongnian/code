    DataTable table = new DataTable();
    table.Columns.Add("column", typeof(string));
    
    table.Rows.Add("1");
    table.Rows.Add("2");
    table.Rows.Add("2");
    table.Rows.Add("3");
    table.Rows.Add("4");
    table.Rows.Add("4");
    
    List<string> searchList = new List<string> { "1", "2" };
    string searchString = "1, 2";
    
    //DataTable.Select(string) example
    var filteredTable = table.Select("column in ("  + string.Join(", ", searchList.ToArray()) + ")");
    //LINQ
    var filteredTable2 = table.AsEnumerable().Where(row => searchList.Contains(row.Field<string>("column"))).CopyToDataTable();
    //using string for search
    var filteredTable3 = table.Select("column in (" + searchString + ")");
