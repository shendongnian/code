    var contactStore = await ContactManager.RequestStoreAsync();
    var contacts = await contactStore.FindContactsAsync();
    var myContact = contacts[0];  //I am sure that this Contact has a Thumbnail
    
    using (var stream = await myContact.Thumbnail.OpenReadAsync())
    {
        byte[] buffer = new byte[stream.Size];
        var readBuffer = await stream.ReadAsync(buffer.AsBuffer(), (uint)buffer.Length, InputStreamOptions.None);
    
        var file = await ApplicationData.Current.LocalFolder.CreateFileAsync("image.jpg", CreationCollisionOption.ReplaceExisting);
        using (var fileStream = await file.OpenStreamForWriteAsync())
        {
            await fileStream.WriteAsync(readBuffer.ToArray(), 0, (int)readBuffer.Length);
        }
    }
 
