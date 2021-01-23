    private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
    {
        DataGridViewCell cell = datagridview.Rows[e.RowIndex].Cells[e.ColumnIndex];
        cell.ToolTipText = cell.ErrorText;
        cell.ErrorText = "";
    }
    private void DGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        DataGridViewCell cell = datagridview.Rows[e.RowIndex].Cells[e.ColumnIndex];
        cell.Style.BackColor = cell.ErrorText != "" ? Color.Salmon : datagridview.BackColor;
    }
