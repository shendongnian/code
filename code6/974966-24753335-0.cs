    var image = new Bitmap("D:\\fish.png"); // location of your image
    var color = Color.Red; //The color in the hue you want to change the image.
    
    for (var x = 0; x < image.Width; x++)
    {
        for (int y = 0; y < image.Height; y++)
        {
            Color originalColor = image.GetPixel(x, y);
            Color changedColor = FromAhsb(originalColor.A, color.GetHue(), originalColor.GetSaturation(), originalColor.GetBrightness());
            image.SetPixel(x,y, changedColor);
        }
    }
    
    image.Save("D:\\new_fish.png", System.Drawing.Imaging.ImageFormat.Png); // location of your new image
