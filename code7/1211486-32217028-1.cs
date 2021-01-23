    Bitmap bitmap = (Bitmap)Image.FromFile(imageFilePath);
    Bitmap temp = new Bitmap(bitmap.Width, bitmap.Height, bitmap.PixelFormat); //Create temporary bitmap
    using (Graphics graphics = Graphics.FromImage(temp))
    {
        using (Font arialFont = new Font("Arial", 10))
        {
            //Copy source image first
            graphics.DrawImage(bitmap, new Rectangle(0, 0, temp.Width, temp.Height), new Rectangle(0, 0, bitmap.Width, bitmap.Height), GraphicsUnit.Pixel);
            graphics.DrawString(firstText, arialFont, Brushes.Blue, firstLocation);
            graphics.DrawString(secondText, arialFont, Brushes.Red, secondLocation);
        }
    }
    bitmap.Dispose(); //Dispose your source image
    temp.Save(imageFilePath);//save the image file
    temp.Dispose(); //Dispose temp after saving
