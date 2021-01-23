    public Form1()
    {
        ...
        originalImage = new Bitmap("C:\\Users\\rati\\Desktop\\water.jpg");
        pictureBox1.Image = originalImage;
        ...
    }
    // Add an extra field to the Form class.
    Bitmap originalImage;
    void trackBar1_Scroll(object sender, EventArgs e)
    {
        pictureBox1.Image = ChangeAlpha((byte)trackBar1.Value);
        textBox1.Text = trackBar1.Value.ToString();
    }
    Image ChangeAlpha(byte alpha)
    {
        Bitmap bmp = new Bitmap(originalImage);
        Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
        BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
        IntPtr ptr = bmpData.Scan0;
        int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
        byte[] rgbValues = new byte[bytes];
        Marshal.Copy(ptr, rgbValues, 0, bytes);
        // Set every fourth value to alpha. A 32bpp bitmap will change transparency.
        for (int counter = 3; counter < rgbValues.Length; counter += 4)
            rgbValues[counter] = alpha;
        // Also you can try parallelize loop.
        //int length = rgbValues.Length / 4;
        //Parallel.For(3, length, counter => rgbValues[counter * 4 - 1] = alpha);
        Marshal.Copy(rgbValues, 0, ptr, bytes);
        bmp.UnlockBits(bmpData);
        return bmp;
    }
