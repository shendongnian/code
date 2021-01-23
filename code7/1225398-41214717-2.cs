    // GET api/values
    [AllowAnonymous]
    public System.Data.DataTable Get() {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable("Test");
        dt.Columns.Add("Col1");
        dt.Columns.Add("Col2");
        DataRow dr = dt.NewRow();
        dr[0] = "Column 1 value";
        dr[1] = "Column 2 value";
        dt.Rows.Add(dr);
        dt.AcceptChanges();
        return dt;
    }
