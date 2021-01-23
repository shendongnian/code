    private void chart1_PrePaint(object sender, ChartPaintEventArgs e)
    {
        LegendCell cell = e.ChartElement as LegendCell;
        if (cell != null && cell.Tag == null) 
        {
            RectangleF r = e.ChartGraphics.GetAbsoluteRectangle(e.Position.ToRectangleF());
            e.ChartGraphics.Graphics.DrawRectangle(Pens.DimGray,Rectangle.Round(r));
            // Let's hide the left border when there is a cell span!
            if (cell.CellSpan != 1) 
                    e.ChartGraphics.Graphics.DrawLine(Pens.White, 
                                    r.Left, r.Top+1, r.Left, r.Bottom-1);
        }
    }
