    public class WorldInstance
    {
        protected WorldTile[,] m_Tiles;
        protected bool[,] m_Discovered;
        public WorldInstance(WorldTile[,] tiles)
        {
            m_Tiles = tiles;
            m_Discovered = new bool[m_Tiles.GetLength(0), m_Tiles.GetLength(1)];
        }
        public WorldTile[,] tiles
        {
            get
            {
                return m_Tiles;
            }
        }
        public bool[,] discoveredTiles
        {
            get
            {
                return m_Discovered;
            }
        }
    }
    public class WorldTile
    {
    }
