    using Microsoft.Band.Tiles;
    ...
    try
    {
        IEnumerable<BandTile> tiles = await bandClient.TileManager.GetTilesAsync();
    }
    catch (BandException ex)
    {
        //handle exception 
    }
    //determine if there is space for tile
    try
    {
        int tileCapacity = await bandClient.TileManager.GetRemainingTileCapacityAsync();
    }
    catch (BandException ex)
    {
        //handle ex
    }
    //create tile
    WriteAbleBitmap smallIconBit = new WriteAbleBitmap(24, 24);
    BandIcon smallIcon = smallIconBit.ToBandIcon();
    WriteAbleBitmap largeIconBit = new WriteAbleBitmap(48, 48);//46, 46 for MS band 1
    BandIcon largeIcon = largeIconBit.ToBandIcon();
    Guid guid = Guid.NewGuid();
    BandTile tile = new BandTile(guid)
    {
        //enable Badging
        IsBadgingEnabled = true,
        Name = "MYNAME"
        SmallIcon = smallIcon;
        TileIcon = largeIcon;
    };
    try
    {
        if(await bandClient.TileManager.AddTileAsync(tile))
        {
             ///console print something
        }
    }
    catch(BandException ex)
    {
        //blabla handle
    }
