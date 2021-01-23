    int count = 100;
    int mSize = 60;
    List<Color> colors = new List<Color>();
    for (int i = 0; i < count; i++)
        colors.Add(Color.FromArgb(255, 255 - i * 2, (i*i) %256, i*2));
    Random R = new Random(99);
    for (int i = 0; i < count; i++)
    {
        int w = 10 + R.Next(50);
        int off = (mSize - w) / 2;
        Bitmap bmp = new Bitmap(mSize, mSize);
        using (Graphics G = Graphics.FromImage(bmp))
        {
            G.Clear(Color.Transparent);
            G.FillRectangle(new SolidBrush(colors[i]), off, off, w, w);
            chart5.Images.Add(new NamedImage("NI" + i, bmp));
        }
    }
    for (int i = 0; i < count; i++)
    {
        int p = chart5.Series["S1"].Points.AddXY(R.Next(100), R.Next(100));
        chart5.Series["S1"].Points[p].MarkerImage = "NI" + p;
    }
