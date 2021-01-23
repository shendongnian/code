    void EventHandler_TileButtonPressed(object sender,
    BandTileEventArgs<IBandTileButtonPressedEvent> e)
    {
     // This method is called when the user presses the
     // button in our tile’s layout.
     //
     // e.TileEvent.TileId is the tile’s Guid.
     // e.TileEvent.Timestamp is the DateTimeOffset of the event.
     // e.TileEvent.PageId is the Guid of our page with the button.
     // e.TileEvent.ElementId is the value assigned to the button
     // in our layout (i.e.,
     // TilePageElementId.Button_PushMe).
     //
     // handle the event
     }
