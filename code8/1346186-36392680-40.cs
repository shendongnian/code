    private void button6_Click(object sender, EventArgs e)
    {
        List<Color> stopColors = new List<Color>()
        { Color.Blue, Color.Cyan, Color.YellowGreen, Color.Orange, Color.Red };
        colorList = interpolateColors(stopColors, 100);
        coloredData = getCData(32, 24);
        // basic setup..
        chart1.ChartAreas.Clear();
        ChartArea CA = chart1.ChartAreas.Add("CA");
        chart1.Series.Clear();
        Series S1 = chart1.Series.Add("S1");
        chart1.Legends.Clear();
        // we choose a charttype that lets us add points freely:
        S1.ChartType = SeriesChartType.Point;
        Size sz = chart1.ClientSize;
        // we need to make the markers large enough to fill the area completely:
        setMarkerSize(chart1);
        createMarkers(chart1, 100);
        // now we fill in the datapoints
        for (int x = 1; x < coloredData.GetLength(0); x++)
            for (int y = 1; y < coloredData.GetLength(1); y++)
            {
                int pt = S1.Points.AddXY(x, y);
                //  S1.Points[pt].Color = coloredData[x, y];
                S1.Points[pt].MarkerImage = "NI" +  coloredData[x,y];
            }
    }
