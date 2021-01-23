    DataTable dt = your_data_source;
    var i = (from j in new string[] { "" }
                     select new
                     {
                         TEXT = "All Stores",
                         VALUE = "ALL",
                     }).AsEnumerable().Union(from k in dt.AsEnumerable()
             select new { TEXT = k.Field<string>("TEXT"), VALUE = k.Field<string>("VALUE") });
        dllist.DataSource = i;
        dllist.DataValueField = "VALUE";
        dllist.DataTextField = "TEXT";
        dllist.DataBind();
