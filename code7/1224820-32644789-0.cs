     public static async Task<string> WriteFie()
        {
          string message = "abc";
          StorageFolder local = await Windows.Storage.ApplicationData.Current.LocalFolder;
          StorageFolder dataFolder = await local.CreateFolderAsync("DataFolder", CreationCollisionOption.OpenIfExists);
          StorageFile file = await dataFolder.CreateFileAsync("Data.txt", CreationCollisionOption.OpenIfExists);
          await FileIO.WriteTextAsync(file, message);
        }
