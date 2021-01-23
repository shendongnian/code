    private static Rectangle[][] tiles;
    private const int worldWidth = 50;
    private const int worldDepth = 50;
    public static void Initialize(Texture2D tileTexture)
    {
        // Initialize game table
        tiles = new Rectangle[worldWidth][];
        for (int l = 0; l < worldWidth; l++)
        {
            tiles[l] = new Rectangle[worldDepth];
        }
        // Fill rectangles in for every tile
        for(int i = 0; i < worldWidth; i++)
        {
            for (int k = 0; k < worldDepth; k++)
            {
                // Tile (0,0): x = 0, y = 0
                // Tile (0,1): x = 0, y = 50
                // and so on...
                tiles[i][k] = new Rectangle(i * TileWidth, k * TileHeight, TileWidth, TileHeight);
            }
        }
    }
