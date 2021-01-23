    var imageBytes = Convert.FromBase64String(base64String);
    using (InMemoryRandomAccessStream ms = new InMemoryRandomAccessStream())
    {
        using (DataWriter writer = new DataWriter(ms.GetOutputStreamAt(0)))
        {
            writer.WriteBytes((byte[])imageBytes);
            writer.StoreAsync().GetResults();
        }
        
        var image = new BitmapImage();
        image.SetSource(ms);
    }
