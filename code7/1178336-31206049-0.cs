    internal class Square
    {
        private double length;
        private double positionX;
        private double positionY;
        public double Length
        {
            get
            {
                return this.length;
            }
        }
        public Square(double p_Length)
        {
            length = p_Length;
            positionX = 0;
            positionY = 0;
        }
        public void SetPosition(double p_PositionX, double p_PositionY)
        {
            positionX = p_PositionX;
            positionY = p_PositionY;
        }
        
        public static List<Square> OrganiseSquares(List<Square> pio_Squares)
        {
            List<Square> squares = pio_Squares.OrderBy(q => q.Length).ToList();
            return squares;
        }
    }
