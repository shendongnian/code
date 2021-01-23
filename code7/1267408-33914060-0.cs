    DataTable table = new DataTable();
    using (var con = new SqlConnection("connection string"))
    using (var da = new SqlDataAdapter("Sql-Query", con))
        da.Fill(table);
    object secondRowSecondColumnValue = table.Rows[1][1];
