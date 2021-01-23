    public static DataTable GetErrorLog(int startRowIndex, int maximumRows, string sortExpression, string logPath)
    {
        if (string.IsNullOrEmpty(sortExpression))
        {
            sortExpression = "fileName DESC";
        }
        DataTable errorLog = GetErrorLogDataTable();
        string[] filePaths = Directory.GetFiles(logPath);
        foreach (string filePath in filePaths)
        {
            DataRow row = errorLog.NewRow();
            row["fileName"] = Path.GetFileName(filePath);
            row["filePath"] = filePath;
            errorLog.Rows.Add(row);
        }
        DataView dataView = new DataView(errorLog);
        dataView.Sort = sortExpression;
        errorLog = dataView.ToTable();
        DataTable pagedErrorLog = errorLog.Clone();
        for (int i = startRowIndex; i < startRowIndex + maximumRows; i++)
        {
            if (i >= errorLog.Rows.Count)
            {
                break;
            }
            pagedErrorLog.ImportRow(errorLog.Rows[i]);
        }
        if (pagedErrorLog.Rows.Count <= 0)
        {
            return errorLog;
        }
        else
        {
            return pagedErrorLog;
        }
    }
    private static DataTable GetErrorLogDataTable()
    {
        DataTable dataTable = new DataTable();
        dataTable.Columns.Add("fileName");
        dataTable.Columns.Add("filePath");
        return dataTable;
    }
