    public class Tile{
        public TileType Type { get; private set; }
        public bool IsWalkable { get; private set; }
        public bool IsBuildSpace { get; private set; }
        public Zone ZoneType { get; private set; }
        public int TileGraphicIndex { get; private set; }
    
        private Tile() {
        }
    
        public static Tile BuildTile(TileType type){
            switch (type) {
                case TileType.WALL:
                    return BuildWallTile();
                case TileType.FLOOR:
                    return BuildFloorTile();
                case TileType.FARMLAND:
                    return BuildFarmlandTile();
                default:
                    throw ArgumentException("type");
            }
        }
    
        public static Tile BuildWallTile()
        {
            return new Tile {
                IsWalkable = false,
                IsBuildSpace = false,
                ZoneType = Zone.None,
                TileGraphicIndex = 1,
                Type = TileType.WALL
            };
        }
    
        public static Tile BuildFloorTile()
        {
            return new Tile {
                IsWalkable = true,
                IsBuildSpace = None,
                ZoneType = Zone.None,
                TileGraphicIndex = 1,
                Type = TileType.FLOOR
            };
        }
    
        public static Tile BuildFarmlandTile()
        {
            return new Tile {
                IsWalkable = true,
                IsBuildSpace = false,
                ZoneType = Zone.Arable,
                TileGraphicIndex = 2,
                Type = TileType.FARMLAND
            };
        }
    
        public enum Zone{
            Shipping,
            Receiving,
            Arable,
            None
        }
        public enum TileType{
            WALL,
            FLOOR,
            FARMLAND
            //...etc
        }
    }
