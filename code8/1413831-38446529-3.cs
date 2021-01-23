    void timer1_Tick(object sender, EventArgs e)
    {
        using(Bitmap Pic = ScreenCaptureBitmap(50, 50, 640, 320)) {
            Image oldImage = pictureBox1.Image;
            using(oldImage)
                pictureBox1.Image = ResizeBitmap(Pic, 128, 64);
        }
    }
