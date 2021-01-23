    if (cell.Value is bool && (bool)cell.Value)
    {
        e.PaintBackground(e.ClipBounds, cell.Selected);
        e.PaintContent(e.ClipBounds);
    
        var x = e.CellBounds.X + e.CellBounds.Width / 2 - size / 2;  //  center of the cell
        var y = e.CellBounds.Y + e.CellBounds.Height / 2 - size / 2; // center of the cell
    
        RectangleF rectangle = new RectangleF(x, y, size, size);
        e.Graphics.FillRectangle(Brushes.Yellow, rectangle);
        e.PaintContent(e.CellBounds);
        e.Handled = true;
    }
