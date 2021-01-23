    public const string AppDBPath = @"ParkingZoneDatabase.db";
    public const string PackageDBPath = @"Databases\ParkingZoneDatabase.db";
    
    
            /// <summary>
            /// Load SQL_LiteTable from Solution   
            /// </summary>
            /// <param name="DBPATH"></param>
            /// <returns></returns>
            public async Task<bool> Init()
            {
    
    
                bool isDatabaseExisting = false;
    
                try
                {
                    StorageFile storageFile = await ApplicationData.Current.LocalFolder.GetFileAsync(AppDBPath);
                    isDatabaseExisting = true;
                }
                catch 
                {
                    isDatabaseExisting = false;
                }
    
               
                    if (!isDatabaseExisting)
                    {
    
                        StorageFile databaseFile = await Package.Current.InstalledLocation.GetFileAsync(PackageDBPath);
                        await databaseFile.CopyAsync(ApplicationData.Current.LocalFolder);
                    }
                
    
                return true;          
            }
    
