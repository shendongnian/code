    DataTable one = new DataTable();
    one.Columns.Add("ID");
    one.Columns.Add("PCT");
    one.Rows.Add("1", "0.0");
    one.Rows.Add("2", "0.1");
    one.Rows.Add("3", "0.2");
    //gvone.DataSource = one;
    //gvone.DataBind();
    DataTable two = new DataTable();
    two.Columns.Add("ID");
    two.Columns.Add("PCT");
    two.Rows.Add("1", "0.0");
    two.Rows.Add("3", "0.3");
    //gvtwo.DataSource = two;
    //gvtwo.DataBind();
    DataTable dt = two.AsEnumerable().Except(one.AsEnumerable(), DataRowComparer.Default)
                                     .CopyToDataTable();
    foreach (DataRow dataRow in dt.AsEnumerable())
    {
        //
    }
