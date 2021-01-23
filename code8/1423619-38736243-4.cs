    private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
    {
        if (cellcolors.Keys.Contains(new Point(e.Column, e.Row )))
            using (SolidBrush brush = new SolidBrush(cellcolors[new Point(e.Column, e.Row )]))
                e.Graphics.FillRectangle(brush, e.CellBounds);
        else
            using (SolidBrush brush = new SolidBrush(defaultColor))
                e.Graphics.FillRectangle(brush, e.CellBounds);
    }
    
