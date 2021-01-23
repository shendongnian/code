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
    	    using(ZipArchive archive = new ZipArchive(stream))
    	    {
    	        foreach (ZipArchiveEntry entry in archive.Entries)
    	        {
    	            IFile zipEntryFile = await rootFolder.CreateFileAsync(entry.Name, CreationCollisionOption.FailIfExists);
    	            using (Stream outPutStream = await zipEntryFile.OpenAsync(FileAccess.ReadAndWrite))
    	            {
    	                await entry.Open().CopyToAsync(outPutStream);
    	            }
    	        }
    	    }
    	}                    
    }
