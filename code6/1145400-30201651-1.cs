    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex < 0) return;                  // no image in the header
        if (e.ColumnIndex == yourImageColumn )
        {
            e.PaintBackground(e.ClipBounds, false);  // no highlighting
            e.PaintContent(e.ClipBounds);
            e.Graphics.DrawString(yourText, yourFont, yourColor, e.CellBounds.Location);
            // maybe draw more text with other fonts etc..
            ..
            e.Handled = true;                        // done with the image column 
        }
    }
