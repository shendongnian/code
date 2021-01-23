    using System.Drawing.Drawing2D;
    GraphicsPath gp = new GraphicsPath();   // a Graphicspath
    gp.AddPolygon(points.ToArray());        // with one Polygon
    Bitmap bmp1 = new Bitmap(555,555);  // ..some new Bitmap
                                        // and some old one..:
    using (Bitmap bmp0 = (Bitmap)Bitmap.FromFile("D:\\test_xxx.png"))
    using (Graphics G = Graphics.FromImage(bmp1))
    {
        G.Clip = new Region(gp);   // restrict drawing region
        G.DrawImage(bmp0, 0, 0);   // draw clipped
        pictureBox1.Image = bmp1;  // show maybe in a PictureBox
    }
