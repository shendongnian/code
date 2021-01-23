        }
        public static Tile wall {
            get {
                return new Tile {
                    IsWalkable = false, 
                    IsBuildSpace = false, 
                    ZoneType = Zone.None, 
                    TileGraphicIndex = 1,
                    Type = TileType.WALL
                 };
             }
         }
         public static Tile floor {
              get {
                  return new Tile {
                      IsWalkable = true, 
                      IsBuildSpace = None, 
                      ZoneType = Zone.None, 
                      TileGraphicIndex = 1,
                      Type = TileType.FLOOR
                  };
              }
         }
         public static Tile farmland {
             get {
                 return new Tile {
                     IsWalkable = true, 
                     IsBuildSpace = false, 
                     ZoneType = Zone.Arable, 
                     TileGraphicIndex = 2, 
                     Type = TileType.FARMLAND
                  };
              }
        }
        public enum Zone{
            Shipping,
            Receiving,
            Arable,
            None
        }
        public enum TileType{ WALL, FLOOR, FARMLAND //...etc }
    }
