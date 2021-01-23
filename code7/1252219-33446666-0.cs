    public class Ball : IBall
    {
        public int Y { get; set; }
        public int X { get; set; }
        public int VX { get; set; }
        public int VY { get; set; }
        public static int Width;
        public static int Speed;
        public int Top
        {
            get
            {
                return Y; 
            }
        }
        public int Left
        {
            get
            {
                return X;
            }
        }
        public int Right
        {
            get
            {
                return X + Ball.Width;
            }
        }
        public int Bottom
        {
            get
            {
                return Y + Ball.Width;
            }
        }
    }
