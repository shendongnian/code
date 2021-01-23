    private DataTable GetDataTableFromObject(List<dynamic> allRecords)
    {
        DataTable dt = new DataTable();
        foreach (dynamic record in allRecords)
        {
            DataRow dr = dt.NewRow();
            foreach (dynamic item in record)
            {
                var prop = (IDictionary<String, Object>)item;
                if (!dt.Columns.Contains(prop["Column_name"].ToString())) //Column_Name = Property name
                {
                    dt.Columns.Add(new DataColumn(prop["Column_name"].ToString()));
                }
                dr[prop["Column_name"].ToString()] = prop["Data"];  //Data = value
            }
            dt.Rows.Add(dr);
        }
    }
