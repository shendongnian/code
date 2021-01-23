    public async void DonwLoadAndStoreZipFile ()
    {
        var bytes = await DownloadImageAsync(null);
    
        // IFolder interface comes from PCLStorage
    
        IFolder rootFolder = FileSystem.Current.LocalStorage;
        IFolder folder = await rootFolder.CreateFolderAsync("zipFolder", CreationCollisionOption.OpenIfExists);
        IFile file = await folder.CreateFileAsync("test.zip" , CreationCollisionOption.OpenIfExists);
    
        using (Stream stream = await file.OpenAsync(FileAccess.ReadAndWrite))
        {
            await stream.WriteAsync(bytes, 0, bytes.Length);
            using (var zf = new ZipFile(stream))
            {
                foreach (ZipEntry zipEntry in zf) 
                {                
                    // Gete Entry Stream.
                    Stream zipEntryStream = zf.GetInputStream(zipEntry);
    
                    // Create the file in filesystem and copy entry stream to it.
                    IFile zipEntryFile = await rootFolder.CreateFileAsync(zipEntry.Name , CreationCollisionOption.FailIfExists);
                    using(Stream outPutFileStream = await zipEntryFile.OpenAsync(FileAccess.ReadAndWrite))
                    {
                        await zipEntryStream.CopyToAsync(outPutFileStream);
                    }
                }
            }
        }                    
    }
