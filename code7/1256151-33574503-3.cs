    private Bitmap _currentImage;
    private void Form1_Paint(object sender, PaintEventArgs e)
    {            
        if (animate)
        {                            
            e.Graphics.DrawImageUnscaled(_currentImage, 0, 0);
        }
        else
        {
            e.Graphics.DrawImageUnscaled(pictureBit, 0, 0);
        }
   }
    private async void start_animate(object sender, EventArgs e)
    {
        animate = true;
        int imageIndex = 1;
        while (animate)
        {
            _currentImage = (Bitmap)Image.FromFile(imageIndex  + ".png");
            Invalidate();
            await Task.Delay(100); // wait 100 milliseconds
            imageIndex++;
            if (imageIndex > 10)
            {
                imageIndex = 1;
            }
        }
    }
