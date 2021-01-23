    public DataTable Convert(DataTable dt1)
    {
        try
        {
            var dt2 = dt1.Clone();
            foreach (DataColumn dc in dt2.Columns)
            {
                dc.DataType = Type.GetType("System.String");
            }
            foreach (DataRow row in dt1.Rows)
            {
                dt2.ImportRow(row);
                DataRow dr = dt2.Rows[dt2.Rows.Count-1]
                foreach (DataColumn dc in dt2.Columns)
                {
                    bool value;
                    if (bool.TryParse(dr[dc].ToString(), out value))
                    {
                        dr[dc] = "+";
                    }
                }
            }
            return dt2;
        }
        finally
        {
        }
    }
