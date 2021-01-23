    public void CropImage(int x, int y, int width, int height)
    {
        string imagePath = "C:\Users\Admin\Desktop\test.jpg";
        Bitmap croppedImage;
        using (var originalImage = new Bitmap(imagePath))
        {
            Rectangle crop = new Rectangle(x, y, width, height);
            croppedImage = originalImage.Clone(crop, originalImage.PixelFormat);
        }
        croppedImage.Save(imagePath, ImageFormat.Jpeg);
    }
