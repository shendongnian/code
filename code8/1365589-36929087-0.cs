    private List<RunSaveItem> GetSavedRunsFromMemory()
    {
        //ClearAll();
        List<RunSaveItem> data;
        string dataFromAppSettings;
        if (IsolatedStorageSettings.ApplicationSettings.TryGetValue(SaveRunsKey, out dataFromAppSettings))
        {
            data = JsonConvert.DeserializeObject<List<RunSaveItem>>(dataFromAppSettings); 
        }
        else
        {
            data = new List<RunSaveItem>();
        }
        return data;
    }
