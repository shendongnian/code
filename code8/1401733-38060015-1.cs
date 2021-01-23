    DataTable dt = new DataTable();
    if (dt.Columns.Count == 0)
    {
         dt.Columns.Add("thing", typeof(string));
         dt.Columns.Add("thing2", typeof(string));
    }
    
    for(int i = 0; i < 3; i++)
    {
         DataRow dr = dt.NewRow();
         dr[0] = "foo";
         dr[1] = "bar";
         dt.Rows.Add(dr);
    }
