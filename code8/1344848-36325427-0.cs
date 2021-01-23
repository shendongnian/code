    Bitmap _bitmap;
    private void BuildImage()
    {
        using (ImageManipulation cls = new ImageManipulation(_bitmap))
        {
            ImageBox.Image.Dispose();
            ImageBox.Image = (Bitmap)cls.AdjustContrast((float)nudContrast.Value, (float)nudBrightness.Value, (float)nudGamma.Value).Clone();
        }
    }
    public class ImageManipulation : IDisposable
    {
        Bitmap _internalBitmapMemory;
        public ImageManipulation(Bitmap bitmap)
        {
            _internalBitmapMemory = new Bitmap(bitmap);
        }
        public Bitmap AdjustContrast(float Contrast = 1, float Brightness = 1, float Gamma = 1)
        {
            float brightness = Brightness;      // no change in brightness
            float contrast = Contrast;          // twice the contrast
            float gamma = Gamma;                // no change in gamma
            float adjustedBrightness = brightness - 1.0f;
            // create matrix that will brighten and contrast the image
            float[][] ptsArray =
            {
                new float[] {contrast,              0,                      0,                      0,                  0},     // scale red
                new float[] {0,                     contrast,               0,                      0,                  0},     // scale green
                new float[] {0,                     0,                      contrast,               0,                  0},     // scale blue
                new float[] {0,                     0,                      0,                      1.0f,               0},     // don't scale alpha
                new float[] {adjustedBrightness,    adjustedBrightness,     adjustedBrightness,     0,                  1}
            };
            var imageAttributes = new ImageAttributes();
            imageAttributes.ClearColorMatrix();
            imageAttributes.SetColorMatrix(new ColorMatrix(ptsArray), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            imageAttributes.SetGamma(gamma, ColorAdjustType.Bitmap);
            Graphics g = Graphics.FromImage(_internalBitmapMemory);
            g.DrawImage(_internalBitmapMemory, new Rectangle(0, 0, _internalBitmapMemory.Width, _internalBitmapMemory.Height)
                , 0, 0, _internalBitmapMemory.Width, _internalBitmapMemory.Height,
                GraphicsUnit.Pixel, imageAttributes);
            g.Dispose();
            return _internalBitmapMemory;
        }
        public void Dispose()
        {
            _internalBitmapMemory.Dispose();
            _internalBitmapMemory = null;
        }
    }
