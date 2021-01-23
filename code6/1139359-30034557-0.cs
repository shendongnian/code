    // bandClient.TileManager.TileButtonPressed += OnTileButtonPressed;
     private async void OnTileButtonPressed(object s, BandTileEventArgs<IBandTileButtonPressedEvent> e)
    {
        try
        {
            buttonPressedCount++;
            ((TextBlockData)page3.Values[2]).Text = buttonPressedCount.ToString();
            await bandClient.TileManager.SetPagesAsync(e.TileEvent.TileId, page, page2, page3);
        }
        catch (BandException ex)
        {
            // Notify
        }
    }
