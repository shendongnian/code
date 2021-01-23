    private void button1_Click(object sender, EventArgs e)
    {
        Bitmap bmp = new Bitmap(pictureBox1.Image);
        using (Graphics g = Graphics.FromImage(bmp))
        {
            g.DrawImage(new Bitmap(@"D:\stop32.png"), new Point(12, 13));
        }
        pictureBox1.Image = bmp;
    }
