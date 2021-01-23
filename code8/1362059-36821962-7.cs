    int newWidth = 100; int newHeight = 100; string yourFileName = "D:\\xyz123.jpg";
    Bitmap bmpSave = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
    Rectangle newRectangle = new Rectangle(0, 0, newWidth, newHeight);
    Rectangle oldRectangle = new Rectangle(Point.Empty, pictureBox1.Image.Size);
    using (Graphics g = Graphics.FromImage(bmpSave))
    {
        g.DrawImage((Bitmap)pictureBox1.Image, newRectangle, oldRectangle, GraphicsUnit.Pixel);
        bmpSave.Save(yourFileName, ImageFormat.Jpeg);
    } 
