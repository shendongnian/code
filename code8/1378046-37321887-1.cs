    foreach (StorageFile contentStream in pickedFile)
    {
        var prop = await contentStream.GetBasicPropertiesAsync();
        DateTimeOffset lastModification = prop.DateModified;
        DateTimeOffset itemTime = prop.ItemDate;
        ulong size = prop.Size;
        //...
    }
