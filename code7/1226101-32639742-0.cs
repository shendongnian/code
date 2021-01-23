    static List<string> parseXml(DataSet ds)
    {
        List<string> list = new List<string>();
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            list.Add(row["ProjectType"].ToString());
        }
        return list;
    }
