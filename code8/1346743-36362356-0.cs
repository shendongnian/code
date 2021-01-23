    DataTable dt = ds.Tables[0];
    dt.Columns.Add(new DataColumn("DistanceResult", System.Type.GetType("System.Double")));
    foreach (DataRow row in dt.Rows)
    {
        ...
        row["DistanceResult"] = distance(...);
    }
    
    gvDistance.DataSource = dt.DefaultView;
    gvDistance.DataBind();
