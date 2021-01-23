    public static void SaveAsGrayscaleJpeg(String loadPath, String savePath)
    {
        using (FileStream fs = new FileStream(savePath, FileMode.Create))
        {
            BitmapSource img = new BitmapImage(new Uri(new FileInfo(loadPath).FullName));
            FormatConvertedBitmap convertImg = new FormatConvertedBitmap(img, PixelFormats.Gray8, null, 0);
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(convertImg));
            encoder.Save(fs);
        }
    }
