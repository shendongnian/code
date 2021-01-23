    public async Task<bool> onCreate(string databasePath)
    {
        try
        {
            if (!await CheckFileExists(databaseName))
            {
                using (databaseConnection = new SQLiteConnection(databaseName))
                {
    
                }
            }
        }
    }
    public static async System.Threading.Tasks.Task<bool> CheckFileExists(string filename)
    {
        bool exists = true;
        try
        {
             Windows.Storage.StorageFile file = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(filename);
        }
        catch (Exception)
        {
             exists = false;
        }
        return exists;
    }
