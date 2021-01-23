    private void setToolTipTexts()	
    {
        foreach (DataGridViewRow row in dgv.Rows)
        {
            if (row.Cells[0].Value != null)
            {
                string columnData = GetDataFromExcel(columnNumber); // columnNumber still has to be determined by you. As well as the method to get the data from excel.
                row.Cells[0].ToolTipText = columnData;
            }
        }
    }
