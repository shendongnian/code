    public static string DB_NAME = "ContactsManager.sqlite";
    public static string DB_PATH = Path.Combine(Path.Combine(ApplicationData.Current.LocalFolder.Path, DB_NAME));//DataBase Name 
    private async Task<bool> CheckFileExistsAsync(string fileName)
    {
        try
        {
            var store = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
            return true;
        }
        catch
        {
        }
        return false;
    }
    if (!(await CheckFileExistsAsync(DB_NAME)))
    {
        using (var db = new SQLiteConnection(DB_PATH))
        {
            db.CreateTable<CONTENT>();
        }
    }
