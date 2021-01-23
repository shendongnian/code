    [Serializable]
    public class GameSaveData
    {
        public string Name { get; set; }
        public int[] LevelSettings { get; set; }
        public int[] GTime { get; set; }
        public ChunkData[] Data { get; set; }
    
        private GameSaveData() 
        {
            // parameter less constrctor
        }
    
        public GameSaveData(string _name, int[] _settings, int[] _time, ChunkData[] _chunks)
        {
            Name = _name;
            LevelSettings = _settings;
            GTime = _time;
            Data = _chunks;
        }
    }
    [Serializable]
    public class TileData
    {
        public int Corners { get; set; }
        public int TypeID { get; set; }
        public int[] FloorSpecs { get; set; } // 0 -- Floor Missing, 1 - Floor Type ID, 2 -- SubFloor Type
    
        public TileData()
        {
            // parameter less constrctor            
        }
    
        public TileData(int _c, int _t, int[] _floorSpecs)
        {
            Corners = _c;
            TypeID = _t;
            FloorSpecs = _floorSpecs;
        }
    }
    
    [Serializable]
    public class ChunkData
    {
        public readonly int[] Position { get; set; }
        public readonly TileData[] Data { get; set; }
    
        public ChunkData()
        {
            // parameter less constrctor                        
        }
    
        public ChunkData(Vector3 _pos, TileData[] _data)
        {
            Position = new int[] { (int)_pos.x, (int)_pos.y, (int)_pos.z };
            Data = _data;
        }
    }
