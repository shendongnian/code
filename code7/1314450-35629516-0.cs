    using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
    {
        using (DataWriter writer = new DataWriter(stream.GetOutputStreamAt(0)))
        {
            writer.WriteBytes(Convert.FromBase64String(base64););
            writer.StoreAsync().GetResults();
        }
    
        BitmapImage image = new BitmapImage();
        image.SetSource(stream);
    }
