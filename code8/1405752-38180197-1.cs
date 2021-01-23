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
                dt.Rows.Add(cols);
            }
            return dt;
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return null;
        }
    }
