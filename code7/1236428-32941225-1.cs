    for (int id=0; id<TileTypeCount; id++)
    {
       TileType tileType = TileType.Get(id); //Get tile by its identifier.
       //Now we have current texture and rectangle (position). Draw it
       DrawRectangleWithTexture(tileType.Rectangle, tileType.Texture);
    }
