    public static void SaveToIsolatedStorage(FileStream fs, string fileName)
    {
        using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
        {
            // Simpler than calling the IsolatedStorageFileStream constructor...
            using (var output = storage.CreateFile(fileName))
            {
                fs.CopyTo(output);
            }
        }
    }
