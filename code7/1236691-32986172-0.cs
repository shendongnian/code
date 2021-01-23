    private async Task<bool> Method1(int workOutID)
    {
        string filename = "WorkoutOfflineDataFile.txt";
        StorageFolder LocalStorageFolderObject = ApplicationData.Current.LocalFolder;
        StorageFile StorageFileObject = await LocalStorageFolderObject.CreateFileAsync(filename, CreationCollisionOption.OpenIfExists);
        using (var stream = await StorageFileObject.OpenStreamForReadAsync())
        {
            using (var reader = new StreamReader(stream))
            {
                string JSONFromFile = reader.ReadToEnd();
            }
        }
    }
    private async void Method2()
    {
        string filename = "WorkoutOfflineDataFile.txt";
        StorageFolder LocalStorageFolderObject = ApplicationData.Current.LocalFolder;
        StorageFile StorageFileObject = await LocalStorageFolderObject.CreateFileAsync(filename, CreationCollisionOption.OpenIfExists);
        using (var stream = await StorageFileObject.OpenStreamForWriteAsync())
        {
            using (var writer = new StreamWriter(stream))
            {
                writer.Write(JSonData_ToSave);
            }
        }
    }
