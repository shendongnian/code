    // aiming at 150dpi and 4x6 inches:
    float dpi = 150;
    float width = 4;
    float height = 6;
    using (Bitmap bmp = new Bitmap((int)(dpi * width), (int)(dpi * height)))
    using (Graphics G = Graphics.FromImage(bmp))
    using (Pen pen = new Pen(Color.Orange)) 
    {
        pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
        G.Clear(Color.FloralWhite);
        Size sz = new System.Drawing.Size((int)dpi * 2 - 1, (int)dpi * 2 - 1);
        G.DrawRectangle(pen, new Rectangle(new Point(0, 0), sz));
        G.DrawRectangle(pen, new Rectangle(new Point(0, 300), sz));
        G.DrawRectangle(pen, new Rectangle(new Point(0, 600), sz));
        G.DrawRectangle(pen, new Rectangle(new Point(300, 0), sz));
        G.DrawRectangle(pen, new Rectangle(new Point(300, 300), sz));
        G.DrawRectangle(pen, new Rectangle(new Point(300, 600), sz));
        bmp.SetResolution(dpi, dpi);
        bmp.Save(@"D:\xxx.jpg", ImageFormat.Jpeg);
    }
