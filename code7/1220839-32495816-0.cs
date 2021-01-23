    using (Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height))
    {
        using (Graphics graphics = Graphics.FromImage(bitmap))
        {
            graphics.Clear(Color.Transparent);
            graphics.DrawImage(pictureBox1.Image, (bitmap.Width - pictureBox1.Image.Width) / 2, (bitmap.Height - pictureBox1.Image.Height) / 2);
        }
        bitmap.Save(@"D:\tmpMod.png", ImageFormat.Png);
    }
