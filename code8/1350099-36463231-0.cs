    /// <summary>
    /// A simple struct to represent a tile on the map
    /// </summary>
    public struct MapTile {
        /// <summary>
        /// The type of the tile
        /// </summary>
        public TileType Type;
        
        /// <summary>
        /// The region this tile is in
        /// </summary>
        public int Region;
        
        /// <summary>
        /// True if this tile is protected
        /// </summary>
        public bool Protected;
        
        /// <summary>
        /// Constructs a new MapTile
        /// </summary>
        /// <param name="type">The type of the tile</param>
        /// <param name="region">The region the tile is in</param>
        /// <param name="isProtected">true if the tile is protected</param>
        public MapTile(TileType type, int region, bool isProtected) {
            this.Type = type;
            this.Region = region;
            this.Protected = isProtected;
        }
    }
    
    /// <summary>
    /// An enum that contains the types of possible tiles
    /// </summary>
    public enum TileType {
        FILLED, CORRIDOR, DOOR, ROOM
    }
