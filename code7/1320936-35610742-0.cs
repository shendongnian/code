    private void DataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex >= 0 && e.RowIndex != this.dataGridView1.Rows.Count - 1)
        {
            DataGridViewRow thisRow = this.dataGridView1.Rows[e.RowIndex];
            DataGridViewRow nextRow = this.dataGridView1.Rows[e.RowIndex + 1];
            if (thisRow.Cells[1].FormattedValue.ToString() != nextRow.Cells[1].FormattedValue.ToString())
            {
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All);
                Rectangle divider = new Rectangle(e.CellBounds.X, e.CellBounds.Y + e.CellBounds.Height - 2, e.CellBounds.Width, 2);
                e.Graphics.FillRectangle(Brushes.Black, divider);
                e.Handled = true;
            }
        }
    }
    private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == 1)
        {
            if (e.RowIndex > 0)
            {
                this.dataGridView1.InvalidateRow(e.RowIndex - 1);
            }
            this.dataGridView1.InvalidateRow(e.RowIndex);
        }
    }
