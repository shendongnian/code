    public static void Save(this BitmapImage image, string filePath)
    {
        BitmapEncoder encoder = new PngBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(image));
        using (var fileStream = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
        {
            encoder.Save(fileStream);
        }
    }
