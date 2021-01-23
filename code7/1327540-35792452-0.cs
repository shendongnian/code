    private void grdRelLinks_CellContentClick(object pSender, DataGridViewCellEventArgs pArgs)
    {
        if (pArgs.RowIndex > -1 && pArgs.ColumnIndex == 2)
        {
            string url = grdRelLinks.Rows[pArgs.RowIndex].Cells[pArgs.ColumnIndex].Value.ToString();
            if(!string.IsNullOrWhiteSpace(url))
                System.Diagnostics.Process.Start(url);
        }
    }
