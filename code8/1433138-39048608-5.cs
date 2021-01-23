    DataTable dt = yourDataTableSource;
    GridView1.DataSource = dt.AsEnumerable().Take(5).CopyToDataTable();
    //Linq example with sorting added
    //GridView1.DataSource = dt.AsEnumerable().OrderBy(x => x["columnName"]).Take(5).CopyToDataTable();
    GridView1.DataBind();
