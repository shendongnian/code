    public static DataTable ArraytoDatatable(Object[,] numbers)
    {                 
        DataTable dt = new DataTable();
        for (int i = 0; i < numbers.GetLength(1); i++)
        {
            dt.Columns.Add("Column" + (i + 1));
        }
    
        for (var i = 0; i < numbers.GetLength(0); ++i)
        {
            DataRow row = dt.NewRow();
            for (var j = 0; j < numbers.GetLength(1); ++j)
            {
                row[j] = numbers[i, j];
            }
            dt.Rows.Add(row);
        }
        return dt;
    }
