    Legend L = chart1.Legends[0];
    Series S = chart1.Series[0];
    // either load an image from disk (or resources)
    Image img = Image.FromFile(someImage);
    // or create it on the fly:
    Bitmap bmp = new Bitmap(32, 14);
    using (Graphics G = Graphics.FromImage(bmp))
    {
        G.Clear(Color.Red);
        G.FillPolygon(Brushes.LimeGreen, new Point[] { new Point(0,0), 
            new Point(32,0), new Point(0,14)});
    }
