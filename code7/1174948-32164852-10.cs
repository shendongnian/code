    private void chart1_SizeChanged(object sender, EventArgs e)
    {
        int pointCount = 12;
        float columnwidth = 0.3f;
        ChartArea CA = chart1.ChartAreas[0];
        int width = (int)(1f * chart1.ClientSize.Width * 
                          CA.InnerPlotPosition.Width / 100f  / pointCount * columnwidth );
        chart1.Series[0].SetCustomProperty("PixelPointWidth", "" + width);
    }
