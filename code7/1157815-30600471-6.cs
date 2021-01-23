    void saveImage(string filename)
    {
        using (Bitmap bmp = new Bitmap(pictureBox1.ClientSize.Width,
                                       pictureBox1.ClientSize.Height))
        {
            pictureBox1.DrawToBitmap(bmp, pictureBox1.ClientRectangle);
            bmp.Save("yourFileName.png", ImageFormat.Png);
        }
    }
