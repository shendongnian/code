    private BitmapImage ConvertImage(string str) {
    byte[] imgData = Convert.FromBase64String(str);
    using (InMemoryRandomAccessStream ms = new InMemoryRandomAccessStream())
    {
        using (DataWriter writer = new DataWriter(ms.GetOutputStreamAt(0)))
        {
            writer.WriteBytes(imgData);
            writer.StoreAsync.GetResults();
        }
        BitmapImage result = new BitmapImage();
        result.SetSource(ms);
        return result;
    }}
