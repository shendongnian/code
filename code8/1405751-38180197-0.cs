    public static DataTable GetCsvStringAsDataTable(string csvContent, char[] rowDelimeter, char[] colDelemiter)
    {
        try
        {
            var lines = csvContent.Split(rowDelimeter, StringSplitOptions.RemoveEmptyEntries);
            if (lines.Length == 0)
            {
                return null;
            }
            var header = lines[0];
            var columns = header.Split(colDelemiter, StringSplitOptions.RemoveEmptyEntries);
            var dt = new DataTable();
            foreach (var column in columns)
            {
                dt.Columns.Add(column);
            }
            foreach (var line in lines.Skip(1))
            {
                var cols = line.Split(colDelemiter, StringSplitOptions.RemoveEmptyEntries);
                DataRow dr = dt.NewRow();
                for (int cIndex = 0; cIndex < cols.Length; cIndex++)
                    dr[cIndex] = cols[cIndex].Trim();
                dt.Rows.Add(dr);
            }
            return dt;
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return null;
        }
    }
