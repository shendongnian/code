    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex < 0) return;                  // no image in the header
        if (e.ColumnIndex == yourImageColumn )
        {
            e.PaintBackground(e.ClipBounds, false);  // no highlighting
            e.PaintContent(e.ClipBounds);
            // calculate the location of your text..:
            int y = e.CellBounds.Bottom - 25;         // your  font height
            e.Graphics.DrawString(yourText, yourFont, yourColor, e.CellBounds.Left, y);
            // maybe draw more text with other fonts etc..
            ..
            e.Handled = true;                        // done with the image column 
        }
    }
