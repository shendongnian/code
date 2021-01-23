    private void chart1_Paint(object sender, PaintEventArgs e)
    {
        ChartArea CA = chart1.ChartAreas[0];
        e.Graphics.DrawRectangle(Pens.Violet, 
                   Rectangle.Round(ChartAreaClientRectangle(chart1, CA)));
        e.Graphics.DrawRectangle(Pens.LimeGreen, 
                   Rectangle.Round(InnerPlotPositionClientRectangle(chart1, CA)));
    }
