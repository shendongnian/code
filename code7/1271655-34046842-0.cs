    DataTable table = new DataTable();
    table.AsEnumerable().CopyToDataTable(); // this works
    List<DataRow> dataRows = new List<DataRow>();
    dataRows.CopyToDataTable(); // this also works
    List<string> strings = new List<string>();
    strings.CopyToDataTable(); // this does not work
