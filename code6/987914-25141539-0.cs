    private void OpenAttachment(DataGridViewCell dgvCell)
        {
            if (SelectedNonNullCellFromColumn(1))
            {
                string s = cncInfoDataGridView.Rows[dgvCell.RowIndex].Cells[5].Value.ToString(); // stores in string s
                System.Diagnostics.Process.Start(s);   ///Open the file
            }
         }
