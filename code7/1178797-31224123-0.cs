        private async Task CopyDatabase()
            {
                bool isDatabaseExisting = false;
                try
                {
                    var s = ApplicationData.Current.LocalFolder.Path;
                    StorageFile storageFile 
                        = await     ApplicationData.Current.LocalFolder.GetFileAsync("DataBase.db");
                    isDatabaseExisting = true;                
                }
                catch
                {
                    isDatabaseExisting = false;
                }
                if (!isDatabaseExisting)
                {
                    StorageFile databaseFile = await 
                        Package.Current.InstalledLocation.GetFileAsync(@"Data\DataBase.db");
                    await databaseFile.CopyAsync(ApplicationData.Current.LocalFolder);                
                }
            }
