    private void DGV_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.ColumnIndex == yourColumn && e.RowIndex == -1)
        {
            e.PaintBackground(e.CellBounds,true);
            e.PaintContent(e.CellBounds);
            // do your drawing stuff
            e.Graphics.DrawEllipse(Pens.Red, e.CellBounds);
            // done
            e.Handled = true;
        }
        // any other cell: let the system do its thing
        else e.Handled = false;
    }
