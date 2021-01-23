    // load the background image:
    this.pictureBox1.BackgroundImage = new Bitmap(yourImageFileName);
    // prepare the image:
    Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
    using (Graphics g  = Graphics.FromImage(bmp) )
    {
        g.FillRectangle(Brushes.Transparent, new Rectangle(Point.Empty, bmp.Size) );
    }
    pictureBox1.Image = bmp;
