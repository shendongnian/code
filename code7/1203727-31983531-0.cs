    DataColum dc = new DataColumn("name");
    
    DataTable dt = new DataTable();
    dt.Columns.Add(column);
    
    DataSet ds = new DataSet();
    ds.Tables.Add(dt);
