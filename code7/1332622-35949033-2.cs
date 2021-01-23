    private void DataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        if (e.ColumnIndex == 0 && e.RowIndex == 0)
        {
            var cell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;
            if (cell != null && e.FormattedValue.ToString() != string.Empty && !cell.Items.Contains(e.FormattedValue))
            {
                cell.Items[0] = e.FormattedValue;
                if (this.dataGridView1.IsCurrentCellDirty)
                {
                    this.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                cell.Value = e.FormattedValue;
            }
        }
    }
