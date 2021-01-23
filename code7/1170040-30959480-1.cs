    private async void SaveFile()
    {
    	try
    	{
    		StorageFolder folder = ApplicationData.Current.LocalFolder;
    		if(folder != null)
    		{
    			StorageFile file = await folder.CreateFileAsync("imagefile", CreationCollisionOption.ReplaceExisting);
    			byte[] fileContnet = null; // This is where you set your content as byteArray
    			Stream fileStream = await file.OpenStreamForWriteAsync();
    			fileStream.Write(fileContent, 0, fileContent.Length);
    			fileStream.Flush();
    			fileStream.Close();
    		}
    	}
    	catch (Exception ex)
    	{
    		// Some Exception handling code
    	}
    }
