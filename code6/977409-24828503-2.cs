    string sValue = "";
    foreach(DataTable dt in ds.Tables)
    {
    	foreach(DataRow dr in dt.Rows)
    	{
    		sValue = dr[0].ToString();
    		// Here you could iterate through the columns collection 
    		//foreach(DataColumn dc in dr.dt.Columns)
    		//{
    		//	sValue = dr(dc.ColumnName).ToString();
    		//}
    	}
    }
