    DataTable dt = new DataTable();
    if (dt.Columns.Count == 0)
    {
        dt.Columns.Add("ColumnA", typeof(string));
        dt.Columns.Add("ColumnB", typeof(string));
    }
    DataRow NewRow = dt.NewRow();
    NewRow[0] = "Some Text";
    NewRow[1] = "Some Other Text";
    dt.Rows.Add(NewRow); 
    GridView1.DataSource = dt;
    GridViewl.DataBind();
