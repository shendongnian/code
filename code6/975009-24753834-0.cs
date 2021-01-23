    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    dt1.Columns.Add("id", typeof(Int32));
    dt2.Columns.Add("Name", typeof(String));
    DataRow dr = dt1.NewRow();
    dr["id"] = 1;
    dt1.Rows.Add(dr);
    dr = dt1.NewRow();
    dr["id"] = 2;
    dt1.Rows.Add(dr);
    dr = dt2.NewRow();
    dr["name"] = "XXX";
    dt2.Rows.Add(dr);
    dr = dt2.NewRow();
    dr["name"] = "YYY";
    dt2.Rows.Add(dr);
    DataTable dt3 = new DataTable();
    dt3.Columns.Add("id", typeof(Int32));
    dt3.Columns.Add("Name", typeof(String));
    for (int i = 0; i < dt1.Rows.Count; i++)
    {
        dr = dt3.NewRow();
        dr["id"] = dt1.Rows[i]["id"];
        dr["name"] = dt2.Rows[i]["name"];
        dt3.Rows.Add(dr);
    }
