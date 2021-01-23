    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        var dg = (DataGridView)sender;  // a short reference
        if (e.ColumnIndex == -5 || e.RowIndex != (dg.RowCount - 1))
            return;
        using (var p = new Pen(Color.Red, 1))
        {
            var cb = e.CellBounds;  // a short reference
            e.PaintBackground(e.ClipBounds, true);
            e.PaintContent(e.ClipBounds);
            e.Graphics.DrawLine(p, cb.X, cb.Y + cb.Height, cb.X + cb.Width, cb.Y + cb.Height);
            e.Handled = true;
        }
    } 
