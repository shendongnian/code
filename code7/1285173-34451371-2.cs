    // aiming at 150dpi and 4x6 inches:
    float dpi = 150;
    float width = 4;
    float height = 6;
    using (Bitmap bmp = new Bitmap((int)(dpi * width), (int)(dpi * height)))
    {
        // first set the resolution
        bmp.SetResolution(dpi, dpi);
        // then create a suitable Graphics object:
        using (Graphics G = Graphics.FromImage(bmp))
        using (Pen pen = new Pen(Color.Orange))
        {
            pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
            G.Clear(Color.FloralWhite);
            // using pixels here:
            Size sz = new System.Drawing.Size((int)dpi * 2 - 1, (int)dpi * 2 - 1);
            G.DrawRectangle(pen, new Rectangle(new Point(0, 0), sz));
            G.DrawRectangle(pen, new Rectangle(new Point(0, 300), sz));
            G.DrawRectangle(pen, new Rectangle(new Point(0, 600), sz));
            G.DrawRectangle(pen, new Rectangle(new Point(300, 0), sz));
            G.DrawRectangle(pen, new Rectangle(new Point(300, 300), sz));
            G.DrawRectangle(pen, new Rectangle(new Point(300, 600), sz));
            // alternative code:
            // we can also set the Graphics object to measure stuff in inches;
            G.PageUnit = GraphicsUnit.Inch;
            // or fractions of it, let's use 10th:
            G.PageScale = 0.1f;
            using (Pen pen2 = new Pen(Color.MediumPurple, 1f / dpi * G.PageScale))
            {
                // draw one rectangle offset by an inch:
                G.DrawRectangle(pen2, 10f, 10f, 20f, 20f);
            }
            bmp.Save(@"D:\xxx.jpg", ImageFormat.Jpeg);
        }
    }
