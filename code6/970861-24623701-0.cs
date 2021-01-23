    public void SaveFile(string path, string data)
    {
        using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication())
        {
            using (var fileStream = new IsolatedStorageFileStream(path + fileName, FileMode.Create, FileAccess.Write, storage))
            {
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    writer.WriteLine(data);
                    writer.Close();
                }
                fileStream.Close();
            }
        }
    }
