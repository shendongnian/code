    private async Task CopyDatabase()
    {
        bool isDatabaseExisting = false;
     
        try
        {
            StorageFile storageFile = await ApplicationData.Current.LocalFolder.GetFileAsync("people.db");
            isDatabaseExisting = true;
        }
        catch
        {
            isDatabaseExisting = false;
        }
     
        if (!isDatabaseExisting)
        {
            StorageFile databaseFile = await Package.Current.InstalledLocation.GetFileAsync("people.db");
            await databaseFile.CopyAsync(ApplicationData.Current.LocalFolder);
        }
    }
