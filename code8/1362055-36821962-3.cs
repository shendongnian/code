    Bitmap bmpSave = new Bitmap(newWidth, newHeight);
    Rectangle newRectangle = new Rectangle(0, 0, newWidth, newHeight);
    using (Graphics g = Graphics.FromImage(bmpSave))
    {
        g.DrawImage((Bitmap)pictureBox1.Image, newRectangle, 
                     pictureBox1.ClientRectangle, GraphicsUnit.Pixel);
        bmpSave.Save(..);
    }
