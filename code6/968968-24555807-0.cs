    public static async Task SaveToIsolatedStorage(Stream fs, string fileName)
        {
            using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (var output = storage.CreateFile(fileName))
                {
                    await fs.CopyToAsync(output);
                }
            }
        }
