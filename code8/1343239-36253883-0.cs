    private void grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex == grid.NewRowIndex || e.RowIndex < 0)
            return;
    
        //I supposed your button column is at index 0
        if (e.ColumnIndex == 0)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.All);
            var x = e.CellBounds.Left + 
                       (e.CellBounds.Width - Properties.Resources.SomeImage.Width) / 2;
            var y = e.CellBounds.Top + 
                       (e.CellBounds.Height - Resources.SomeImage.Height) / 2;
            e.Graphics.DrawImage(Properties.Resources.SomeImage, new Point(x, y));
    
            e.Handled = true;
        }
    }
