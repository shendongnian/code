    private void button3_Click(object sender, EventArgs e)
    {
        Bitmap bmp = new Bitmap(pictureBox2.Image);
         // whatever your plans where, we don't know ;-)
        // RectangleF rectf = new RectangleF(640F, 1100F, 0, 0);
        Graphics g = Graphics.FromImage(bmp);
        // DrawImage needs an image, not a string
        g.DrawImage(new Bitmap(@"C:\Users\Mena\Desktop\1.png"), new Point(182, 213));
        // ! not flush, but dispose is the command to get rid of GDI elements
        g.Dispose();
        pictureBox2.Image = bmp;
    }
