    int blue = 0;
    private void timer1_Tick(object sender, EventArgs e)
    {
        // either dispose of the old Bitmap or simply reuse it!
        if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
        pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        int x, y;
        blue = (blue+1) % 256;
        Text = blue + "";
        for (y = 0; y < 256; y++)
        {
            for (x = 0; x < 256; x++)
            {
                ((Bitmap)pictureBox1.Image).SetPixel(x, y, Color.FromArgb(y, x, blue));
            }
        }
        pictureBox1.Refresh();
    }
