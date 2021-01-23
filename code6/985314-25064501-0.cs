    using UnityEngine;
    
    class TileCreator : MonoBehaviour
    {
        private static System.Random rng = new System.Random();
    
        public GameObject[] TilePrefabs;
    
        public int TilesWide;
    
        public int TilesHigh;
    
        public Vector3 TileMapTopLeft;
    
        void Start()
        {
            for (int x = 0; x < TilesWide; x++)
            {
                for (int y = 0; y < TilesHigh; y++)
                {
                    Instantiate(TilePrefabs[rng.Next(TilePrefabs.Length)], new Vector3(x + TileMapTopLeft.x, y + TileMapTopLeft.y, TileMapTopLeft.z), Quaternion.identity);
                }
            }
        }
    }
