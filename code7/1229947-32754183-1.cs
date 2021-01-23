    private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
    {
        e.PaintCells(e.ClipBounds, DataGridViewPaintParts.All);
    
        e.PaintHeader(DataGridViewPaintParts.Background
            | DataGridViewPaintParts.Border
            | DataGridViewPaintParts.Focus
            | DataGridViewPaintParts.SelectionBackground
            | DataGridViewPaintParts.ContentForeground);
        e.Handled = true;
    }
    
    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        this.dataGridView1.Rows[e.RowIndex].HeaderCell.Value = e.RowIndex.ToString();
    }
