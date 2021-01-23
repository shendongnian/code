    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex < 0) return;
        if (e.ColumnIndex == yourImageColumn )
        {
            e.PaintBackground(e.ClipBounds, false);
            e.PaintContent(e.ClipBounds);
            e.Graphics.DrawString(yourText, yourFont, yourColor, e.CellBounds.Location);
            // maybe draw more text with other fonts etc..
            ..
            // done with the image column 
            e.Handled = true;
        }
    }
