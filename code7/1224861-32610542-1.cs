    Bitmap bmp = new Bitmap(richTextBox1.Width, richTextBox1.Height);
    Graphics g = Graphics.FromImage(bmp);
    g.CopyFromScreen(this.PointToScreen(richTextBox1.Location), new Point(0, 0), bmp.Size);
    bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
    g.Dispose();
    bmp.Dispose();
