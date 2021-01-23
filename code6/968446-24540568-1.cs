    public static void SaveToIsolatedStorage(Stream input, string fileName)
    {
        using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
        {
            // Simpler than calling the IsolatedStorageFileStream constructor...
            using (var output = storage.CreateFile(fileName))
            {
                input.CopyTo(output);
            }
        }
    }
