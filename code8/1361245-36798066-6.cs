    int count = 100;
    int mSize = 60;                           // marker size
    List<Color> colors = new List<Color>();   // a color list
    for (int i = 0; i < count; i++)
        colors.Add(Color.FromArgb(255, 255 - i * 2, (i*i) %256, i*2));
    Random R = new Random(99);
    for (int i = 0; i < count; i++)  // create and store the marker images
    {
        int w = 10 + R.Next(50);     // inner width of visible marker
        int off = (mSize - w) / 2;
        Bitmap bmp = new Bitmap(mSize, mSize);
        using (Graphics G = Graphics.FromImage(bmp))
        {
            G.Clear(Color.Transparent);
            G.FillRectangle(new SolidBrush(colors[i]), off, off, w, w);
            chart5.Images.Add(new NamedImage("NI" + i, bmp));
        }
    }
    for (int i = 0; i < count; i++)    // now add a few points to random locations
    {
        int p = chart5.Series["S1"].Points.AddXY(R.Next(100), R.Next(100));
        chart5.Series["S1"].Points[p].MarkerImage = "NI" + p;
    }
