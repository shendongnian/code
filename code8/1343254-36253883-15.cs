    private void grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex < 0)
            return;
    
        //I supposed your button column is at index 0
        if (e.ColumnIndex == 0)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.All);
            var w = Properties.Resources.SomeImage.Width;
            var h = Properties.Resources.SomeImage.Height;
            var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
            var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
            e.Graphics.DrawImage(someImage, new Rectangle(x, y, w, h));
            e.Handled = true;
        }
    }
