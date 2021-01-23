    var myStorageFile = await Package.Current.InstalledLocation.GetFileAsync("LiveTileTemplate.xml");
    string liveTileTemplate = await FileIO.ReadTextAsync(myStorageFile);
    liveTileTemplate = liveTileTemplate.Replace("squareImageSource", FilePathFullPrefix + GetFilePathSquareTile(imageID));
    TileUpdateManager.CreateTileUpdaterForApplication().EnableNotificationQueue(true);
    TileUpdateManager.CreateTileUpdaterForApplication().Update(new TileNotification(mergedXML));
