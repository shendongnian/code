    ...
    Bitmap image = new Bitmap(rect.Width, rect.Height, pf);
    using (Graphics g = Graphics.FromImage(image))
    {
        g.Clear(Color.Orange);
    }
    print(image, e);
