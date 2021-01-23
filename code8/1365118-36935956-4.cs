    private async Task WriteToLogFile(string message, string messageType)
    {
    	var storageFolder = await GetStorageFolder();
    	var file = await storageFolder.CreateFileAsync(FormatDateForLogName(), CreationCollisionOption.OpenIfExists);
    	try
    	{
    		using (StreamWriter writer = new StreamWriter(await file.OpenStreamForWriteAsync(), Encoding.UTF8))
    		{
    			writer.BaseStream.Seek(writer.BaseStream.Length, SeekOrigin.Begin);
    			writer.Write(string.Format("{0}{1} - {2}: {3}", System.Environment.NewLine, FormatLogPrefix(), messageType, message));
    		}
    	}
    	catch (Exception err)
    	{
    		System.Diagnostics.Debug.WriteLine(err.Message);
    	}
    }
    private async Task<StorageFolder> GetStorageFolder()
    {
    	StorageFolder local = ApplicationData.Current.LocalFolder;
    	return await local.CreateFolderAsync(LogFolderName, CreationCollisionOption.OpenIfExists);
    }
