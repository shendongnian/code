    public DataTable ConvertToDataTable(List<int> o)
    {
        DataTable dt = new DataTable("OutputData");
        dt.Columns.Add("Integers", Type.GetType("System.Int32"));  
        foreach (var item in o)
        {
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            dt.Rows[dt.Rows.Count - 1][0] = item;
        }           
        return dt;
    }
