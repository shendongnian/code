    void createMarkers(Chart chart, int count)
    {
        // rough calculation:
        int sw = chart.ClientSize.Width / coloredData.GetLength(0);
        int sh = chart.ClientSize.Height / coloredData.GetLength(1);
        // clean up previous images:
        foreach(NamedImage ni in chart1.Images) ni.Dispose();
        chart.Images.Clear();
        // now create count images:
        for (int i = 0; i < count; i++)
        {
            Bitmap bmp = new Bitmap(sw, sh);
            using (Graphics G = Graphics.FromImage(bmp))
                G.Clear(colorList[i]);
            chart.Images.Add(new NamedImage("NI" + i, bmp));
        }
    }
