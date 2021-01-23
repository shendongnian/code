    DataTable tblExport = new DataTable();
    tblExport.Columns.Add("ID", typeof(int));
    tblExport.Columns.Add("Name", typeof(string));
    tblExport.Columns.Add("DateofBirth", typeof(DateTime)).AllowDBNull = false;
    tblExport.Columns.Add("DateofDeath", typeof(DateTime)).AllowDBNull = true;
    tblExport.Rows.Add(1, "Tim", new DateTime(1973, 7, 9), DBNull.Value);
    tblExport.Rows.Add(2, "Jim", new DateTime(1953, 3, 19), new DateTime(2011, 1, 2));
    tblExport.Rows.Add(3, "Toby", new DateTime(1983, 4, 23), DBNull.Value);
