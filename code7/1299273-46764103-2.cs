    private string getFirstVisibileSheet(DataTable dtSheet, int index = 0)
    {
        string sheetName = String.Empty;
        if (dtSheet.Rows.Count >= (index + 1))
        {
            sheetName = dtSheet.Rows[index]["TABLE_NAME"].ToString();
            if (sheetName.Contains("FilterDatabase"))
            {
                return getFirstVisibileSheet(dtSheet, ++index);
            }
        }
        return sheetName;
    }
