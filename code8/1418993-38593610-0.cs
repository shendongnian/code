    Chart ch = new Chart();
    // Edit for your Chart Title
    ch.Titles.Add(new Title("chart For Saving"));
    // To display your tt series on the legend
    ch.Legends.Add(new Legend());
    ch.ChartAreas.Add(new ChartArea());
    ch.Series.Add("tt");
    ch.Series["tt"].Points.AddXY(1, 10);
    ch.Series["tt"].Points[0].SetValueY(4);
    string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "savedImg.jpg");
    ch.SaveImage(path, ChartImageFormat.Jpeg);
