    public static DataTable ArraytoDatatable(Object[,] numbers)
    {                 
        DataTable dt = new DataTable();
        for (int i = 0; i < numbers.Rank; ++i)
        {
            dt.Columns.Add("Column" + (i + 1));
        }
    
        for (var i = 0; i < numbers.GetLongLength(1); ++i)
        {
            DataRow row = dt.NewRow();
            for (var j = 0; j < numbers.Rank; ++j)
            {
                row[j] = numbers[j, i];
            }
            dt.Rows.Add(row);
        }
        return dt;
    }
