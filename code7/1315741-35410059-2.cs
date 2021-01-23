    private void tableLayoutPanel1_MouseMove(object sender, MouseEventArgs e)
    {
        tableLayoutPanel1.Invalidate();
    }
    private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
    {
        Point pt = tableLayoutPanel1.PointToClient(Cursor.Position);
        using (SolidBrush brush = new SolidBrush(e.CellBounds.Contains(pt) ? 
                                                 Color.Red : tableLayoutPanel1.BackColor))
            e.Graphics.FillRectangle(brush, e.CellBounds);
    }
