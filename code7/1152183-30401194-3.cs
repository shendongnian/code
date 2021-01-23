    DataTable one = new DataTable();
    one.Columns.Add("ID");
    one.Columns.Add("PCT");
    one.Rows.Add("1", "0.1");
    one.Rows.Add("2", "0.2");
    one.Rows.Add("3", "0.3");
    //gvone.DataSource = one;
    //gvone.DataBind();
    DataTable two = new DataTable();
    two.Columns.Add("ID");
    two.Columns.Add("PCT");
    two.Columns.Add("OldPCT");
    two.Rows.Add("1", "0.1", "0");
    two.Rows.Add("2", "0.1", "0");
    two.Rows.Add("3", "0.9", "0");
    two.Columns.Remove("OldPCT");
    //gvtwo.DataSource = two;
    //gvtwo.DataBind();
    DataTable three = two.AsEnumerable().Except(one.AsEnumerable())
                                        .CopyToDataTable();
    foreach (DataRow dr in three.AsEnumerable())
    {
        string id = dr["ID"].ToString();
        string pct = dr["PCT"].ToString();
    }
