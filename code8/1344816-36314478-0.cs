    public DataTable Convert2(DataTable dt1)
    {
        DataTable dt2 = dt1.Clone();
        // Alter all columns datatype
        foreach (DataColumn col in dt2.Columns)
            col.DataType = typeof(string);
        // Import all rows from existing table
        foreach (DataRow row in dt1.Rows)
            dt2.ImportRow(row);
        // Index the boolean columns that will require evaluation
        List<int> booleans = new List<int>();
        foreach (DataColumn col in dt1.Columns)
        {
            if (col.DataType == typeof(bool))
                booleans.Add(col.Ordinal);
        }
        // Since two tables will be identical except for datatypes 
        // iterate over original table and cast instead of performing
        // a string conversion and parsing the result.
        for (int row = 0; row < dt1.Rows.Count; row++)
        {
            foreach (int index in booleans)
            {
                if ((bool) dt1.Rows[row][index])
                    dt2.Rows[row][index] = "+";
            }
        }
        return dt2;
    }
