    public static void Clean()
    {
        try
        {
            StorageFolder localDirectory = ApplicationData.Current.LocalFolder;
            string path = localDirectory.Path;
            path = path.Substring(0, path.LastIndexOf("\\")) + @"\AC\Microsoft\CryptnetFlushCache\MetaData";
            Directory.Delete(path, true);
        }
        catch (Exception ex)
        {
            Debug.WriteLine("ERROR CLEANING CACHE: " + ex.Message);
        }
    }
