    private void button3_Click(object sender, EventArgs e)
    {
        Bitmap bmp = new Bitmap(pictureBox2.Image);
        using (Graphics g = Graphics.FromImage(bmp))
        {
            g.DrawImage(new Bitmap((@"C:\Users\Mena\Desktop\1.png"), new Point(182, 213));
        }
        pictureBox2.Image = bmp;
    }
