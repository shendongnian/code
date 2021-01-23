    // Load from file or any other source.
    var uri = new Uri(@"D:\InputImage.jpg");
    var bitmap = new BitmapImage(uri);
    // Save to file.
    var encoder = new JpegBitmapEncoder(); // Or any other, e.g. PngBitmapEncoder for PNG.
    encoder.Frames.Add(BitmapFrame.Create(bitmap));
    encoder.QualityLevel = 100; // Set quality level 1-100.
    using (var stream = new FileStream(@"D:\OutputImage.jpg", FileMode.Create))
    {
        encoder.Save(stream);
    }
