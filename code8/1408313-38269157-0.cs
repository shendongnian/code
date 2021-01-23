    public class Ball
    {
        private int Size { get; set; }
        private Color BallColor { get; set;}
    
        Ball(int size, Color color)
        {
            Size = size;
            BallColor = color;
        }
    
        public Color GetBallColor()
        {
            return BallColor;
        }
    }
