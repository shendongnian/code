    private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
    {
        if (e.Row == e.Column)
            using (SolidBrush brush = new SolidBrush(Color.AliceBlue))
                e.Graphics.FillRectangle(brush, e.CellBounds);
        else
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(123, 234, 0)))
                e.Graphics.FillRectangle(brush, e.CellBounds);
    }
