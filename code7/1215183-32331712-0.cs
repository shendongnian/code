         StorageFolder externalDevices = Windows.Storage.KnownFolders.RemovableDevices;
    
                // Get the first child folder, which represents the SD card.
                StorageFolder sdCard = (await externalDevices.GetFoldersAsync()).FirstOrDefault();
    
                if (sdCard != null)
                {
                    // An SD card is present and the sdCard variable now contains a reference to it.
                    var output1 = await sdCard.CreateFileAsync("Test.txt", CreationCollisionOption.OpenIfExists);
                }
                else
                {
                    // No SD card is present.
                }
