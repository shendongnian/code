    public static byte[] ImageToString(System.Windows.Media.Imaging.BitmapImage img) {
        System.IO.MemoryStream stream = new System.IO.MemoryStream();
        System.Windows.Media.Imaging.BmpBitmapEncoder encoder = new System.Windows.Media.Imaging.BmpBitmapEncoder();
        encoder.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create((System.Windows.Media.Imaging.BitmapSource)img));
        encoder.Save(stream);
        stream.Flush();
        return stream.ToArray();
    }
