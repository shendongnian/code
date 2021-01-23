    private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
    {
        using (var b = new SolidBrush(bgColors[e.Column, e.Row]))
        {
            e.Graphics.FillRectangle(b , e.CellBounds);
        }
    }
