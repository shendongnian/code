    if (cell.Value is bool && (bool)cell.Value)
    {
        e.PaintBackground(e.ClipBounds, cell.Selected);    
    
        //  center of the cell
        var x = e.CellBounds.X + e.CellBounds.Width / 2 - size / 2;  
        var y = e.CellBounds.Y + e.CellBounds.Height / 2 - size / 2;
        RectangleF rectangle = new RectangleF(x, y, size, size);
        e.Graphics.FillRectangle(Brushes.Yellow, rectangle);
    
        e.PaintContent(e.ClipBounds);
    
        e.Handled = true;
    }
