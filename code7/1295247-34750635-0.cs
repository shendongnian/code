    // Create or overwrite file target file in local app data folder
    var fileToWrite = await ApplicationData.Current.LocalFolder.CreateFileAsync("myWorkingStreamIOfile.pcm", CreationCollisionOption.ReplaceExisting);
    // Open file in application package
    var fileToRead = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/myFileInMyProjectAssets.pcm", UriKind.Absolute));
    byte[] buffer = new byte[1024];
    using (BinaryWriter fileWriter = new BinaryWriter(await fileToWrite.OpenStreamForWriteAsync()))
    {
        using (BinaryReader fileReader = new BinaryReader(await fileToRead.OpenStreamForReadAsync()))
        {
            long readCount = 0;
            while (readCount < fileReader.BaseStream.Length)
            {
                int read = fileReader.Read(buffer, 0, buffer.Length);
                readCount += read;
                fileWriter.Write(buffer, 0, read);
            }
        }
    }
