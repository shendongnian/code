    public class Level
    {
        public int LevelIndex{ get; set; }
        public Cube[] Cubes { get; set; }
    
        public Level(int level)
        {
            LevelIndex = level;
        }
        //method to add Cube to the array of Cubes
    }
    public class Cube
        {
            public int Type { get; set; }
            public int positionx { get; set; }
            public int positiony { get; set; }
            public int positionz { get; set; }
        
            public Cube(int type,int x,int y,int z)
            {
                Type = type;
                positionx = x;
                positiony = y;
                positionz = z;
            }
     }
