    private void dataGridView1_CellPainting(object sender, 
                   DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex < 0) return;  // header? nothing to do!
        if (e.ColumnIndex == yourAnnotatedColumnIndex )
        {
            DataGridViewCell cell = dataGridView1[e.ColumnIndex, e.RowIndex];
            string footnote = "";
            if (cell.Tag != null) footnote = cell.Tag.ToString();
            int y = e.CellBounds.Bottom - 15;  // pick your  font height
            e.PaintBackground(e.ClipBounds, true); // show selection? why not..
            e.PaintContent(e.ClipBounds);          // normal content
            using (Font smallFont = new Font("Times", 8f))
                e.Graphics.DrawString(footnote, smallFont,
                  cell.Selected ? Brushes.White : Brushes.Black, e.CellBounds.Left, y);
            e.Handled = true;
        }
    }
