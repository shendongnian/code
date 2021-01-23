    public async void CopyDatabaseIfNotExists(string dbPath)
    {
      IStorageFolder applicationFolder = ApplicationData.Current.LocalFolder;
      var existingFile = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(myDBFileName);
      if (!await CheckForExistingFile(myDBFileName))
        await existingFile.CopyAsync(applicationFolder);
    }
    private async Task<bool> CheckForExistingFile(string filePath)
    {
      try
      {
        var file = await ApplicationData.Current.LocalFolder.GetFileAsync(Uri.EscapeDataString(filePath));
        //no exception means file exists
        return true;
      }
      catch (FileNotFoundException ex)
      {
        //find out through exception
        return false;
      }
    }
