    var ras = new InMemoryRandomAccessStream();
    var writer = new DataWriter(ras);
    writer.WriteBuffer(buffer);
    await writer.StoreAsync();
    var inputStream = ras.GetInputStreamAt(0);
                                
    // you can still use this to display it on the UI though
    //bmp.SetSource(ras);
    
    // write the picture into this folder
    var storageFile = await folder.CreateFileAsync("image1.jpg", CreationCollisionOption.GenerateUniqueName);
    using (var storageStream = await storageFile.OpenAsync(FileAccessMode.ReadWrite))
    {
        await RandomAccessStream.CopyAndCloseAsync(inputStream, storageStream.GetOutputStreamAt(0));
    }
