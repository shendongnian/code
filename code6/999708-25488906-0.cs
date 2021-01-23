    public class Battlefield<T> where T: Game
    {
        public Tile[,] Tiles { get; set; }
        public T Game { get; set; }
        public Battlefield(int sizeX, int sizeY, T game)
        {
            Tiles = new Tile[sizeX, sizeY];
            Game = game;
        }
        public Tile GetTile(int x, int y)
        {
            return Tiles[x, y];
        }
    }
    public class ServerBattleField : Battlefield<ServerGame> 
    {
        public ServerBattleField(int sizeX, int sizeY, ServerGame game)
            : base(sizeX, sizeY, game)
        {
        }
        public void DoSomethingServerSpecific()
        {
            Game.DoSomethingServerSpecialWithTile(10, 5);
        }
    }
