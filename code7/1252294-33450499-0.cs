    Bitmap bmp = new Bitmap(width*2, height*2);
    Graphics graph = Graphics.FromImage(bmp);
    graph.InterpolationMode = InterpolationMode.High;
    graph.CompositingQuality = CompositingQuality.HighQuality;
    graph.SmoothingMode = SmoothingMode.AntiAlias;
    graph.DrawImage(image, new Rectangle(0, 0, width*2, height*2));
