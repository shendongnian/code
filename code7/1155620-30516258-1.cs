    private void DGV_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.ColumnIndex == yourColumn && e.RowIndex == -1)
        {
            DGV.ColumnHeadersHeight = 32;
            // should be prepared, maybe in an imagelist!!
            Image img = Image.FromFile("D:\\dollars96.png");
            Rectangle r32 = new Rectangle(e.CellBounds.Left, 0, 32,32);
            Rectangle r96 = new Rectangle(0, 0, 96,96);
            string header = DGV.Columns[e.ColumnIndex].HeaderText;
            e.PaintBackground(e.CellBounds, true);  // or maybe false ie no selection?
            //e.PaintContent(e.CellBounds);  // no, we want to draw the text ourselves
            e.Graphics.DrawString(header, DGV.Font, Brushes.Black, e.CellBounds.Left + 33, 6);
            e.Graphics.DrawImage(img, r32, r96, GraphicsUnit.Pixel);
            e.Handled = true;
        }
        // any other cell: let the system do its thing
        else e.Handled = false;
    }
