     for (int i = 0; i < 5; i++)
                {
                    var secondaryTile = new SecondaryTile(
                               i.ToString(),
                               "Text shown on tile",
                               "secondTileArguments",
                               new Uri("ms-appx:///Images/image.png", UriKind.Absolute),
                               TileSize.Square150x150);
    
                    bool isPinned = await secondaryTile.RequestCreateAsync();
                }
  
