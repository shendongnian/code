    Uri Squarelogo = new Uri(ms-appx:///TileImages/150x150.jpg, UriKind.RelativeOrAbsolute);
    Uri smalllogo = new Uri(ms-appx::///TileImages/30x30.jpg, UriKind.RelativeOrAbsolute);
    var tileActivationArguments = "MySecondaryTile Was Pinned At " + DateTime.Now.ToLocalTime().ToString();
    
    SecondaryTile secondaryTile = new SecondaryTile(ShowId, title, tileActivationArguments, Squarelogo, TileSize.Square150x150);
    secondaryTile.VisualElements.ForegroundText = ForegroundText.Light;
    secondaryTile.VisualElements.Wide310x150Logo = Squarelogo;
    secondaryTile.VisualElements.Square30x30Logo = smalllogo;
    secondaryTile.VisualElements.ShowNameOnSquare150x150Logo = true;
    secondaryTile.VisualElements.ShowNameOnWide310x150Logo = true;
    
    await secondaryTile.RequestCreateAsync();
                       
