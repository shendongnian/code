    Bitmap bmp = new Bitmap(1000, 1000);
    using (Graphics g = Graphics.FromImage(bmp))
    {
        g.FillRectangle(Brushes.Green, 0, 0, 10, 10);
        g.DrawEllipse(Pens.Black, 10, 10, 900, 900);
    }
    pictureBox1.Image = bmp;
