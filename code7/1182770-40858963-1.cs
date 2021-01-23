    public int GetTotalRowCount(bool warrant = false)
    {
        IRow headerRow = activeSheet.GetRow(0);
        if (headerRow != null)
        {
            int rowCount = activeSheet.LastRowNum + 1;
            return rowCount;
        }
        return 0;
    }
