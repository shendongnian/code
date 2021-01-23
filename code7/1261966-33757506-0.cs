    public async Task<UInt64> GetLocalFolderFreeSpaceAsync()
        {
            var retrivedProperties =
                await ApplicationData.Current.LocalFolder.Properties.RetrievePropertiesAsync(new string[] {"System.FreeSpace"});
            return (UInt64) retrivedProperties["System.FreeSpace"];
        }
