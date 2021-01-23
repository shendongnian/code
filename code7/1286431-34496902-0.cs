    private void timer1_Tick(object sender, EventArgs e)
    {
        Image img = pictureBox2.BackgroundImage;
        int r = img.Height / 3; // simulate some test data 
        int level = R.Next(r) + R.Next(r) + R.Next(r);
        pictureBox2.Refresh();
        using ( Graphics G = pictureBox2.CreateGraphics() )
            G.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height - level),
                new Rectangle(0, 0, img.Width, img.Height - level), GraphicsUnit.Pixel);
    }
