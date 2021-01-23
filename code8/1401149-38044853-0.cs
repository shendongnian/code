    public class GameTiles : MonoBehaviour {
        public GameTile redTile;
        public GameObject redTilePrefab;
        public bool redTileIsPassable;
        public float redTileMoveCost;
        public void Main() {
            this.redTile = new GameTile();
            this.redTile.tilePrefab = redTilePrefab;
            this.redTile.isPassable = redTileIsPassable;
            this.redTile.moveCost = redTileMoveCost;
            print(this.redTile);
        }
    }
