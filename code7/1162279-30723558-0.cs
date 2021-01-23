    DataSet ds = new DataSet();
    DataTable dt = new DataTable("ExampleTable");
    dt.Columns.Add(new DataColumn("Age",typeof(int)));
    dt.Columns.Add(new DataColumn("Name", typeof(string)));
    DataRow dr = dt.NewRow();
    dr["Age"] = 30;
    dr["Name"] = "Mike";
    dt.Rows.Add(dr);
    ds.Tables.Add(dt);
