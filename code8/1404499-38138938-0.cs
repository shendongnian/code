    void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if ((e.ColumnIndex == this.dataGridView1.Columns["column_name"].Index)  && e.Value != null)
        {
            DataGridViewCell cell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            cell.ToolTipText = "This is given ToolTip";
        }
    }
