    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (dataGridView1.CurrentCell != null && e.RowIndex != -1 && e.ColumnIndex != -1 &&
            dataGridView1.CurrentCell.RowIndex == e.RowIndex &&
            dataGridView1.CurrentCell.ColumnIndex == e.ColumnIndex)
        {
            e.Paint(e.ClipBounds, e.PaintParts);
            var pen = new Pen(Color.Red) { DashStyle = DashStyle.Dash };
            var rect = new Rectangle(e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Width - 2, e.CellBounds.Height - 2);
            e.Graphics.DrawRectangle(pen, rect);
            e.Handled = true;
        }
    }
