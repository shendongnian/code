    private void chart1_PrePaint(object sender, ChartPaintEventArgs e)
    {
        LegendCell cell = e.ChartElement as LegendCell;
        if (cell != null && cell.Tag == null) 
        {
            RectangleF r = e.ChartGraphics.GetAbsoluteRectangle(e.Position.ToRectangleF());
            e.ChartGraphics.Graphics.DrawRectangle(Pens.DimGray,Rectangle.Round(r));
        }
    }
