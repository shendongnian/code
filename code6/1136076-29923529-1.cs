    foreach(DataTable dt in ds.Tables)
    {
        foreach(DataRow dr in dt.Rows)
        {
            Customer oC = new Customer(); 
            foreach(DataColumn dc in dt.Columns)
            {
                if(p.Name == dc.ColumnName)
                {
                    p.SetValue(oC, dr[dc].ToString());
                }
            }
            lCustomers.Add(oC);  
        }
    }
