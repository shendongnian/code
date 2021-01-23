    if (value <= -0.8f)
    {
        Tiles.Add(new Tile(Main.TileGrass, new Vector2((int)x * Tile.Size, (int)y * Tile.Size)));
    }
    else if (value <= 0)
    {
        Tiles.Add(new Tile(Main.TileSand, new Vector2((int)x * Tile.Size, (int)y * Tile.Size)));
    }
    else
    {
        Tiles.Add(new Tile(Main.TileWater, new Vector2((int)x * Tile.Size, (int)y * Tile.Size)));
    }
