    // TileMap class:
    public bool IsPassable(int x, int y)
    {
        if (x < 0 || x >= Width || y < 0 || y >= Height)
            return false;
        return tiles[x][y] != Tile.Wall;  // enum Tile { Wall, Ballroom, DiningRoom, Hall, ... }
    }
    // When called from your Board code:
    if (map.IsPassable(currentLocation.X, currentLocation.Y + 1))
        startBlocks.Add(new Point(currentLocation.X, currentLocation.Y + 1));
