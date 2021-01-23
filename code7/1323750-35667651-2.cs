    public class Card : ICard
    {    
        ...
        public const int MaxSizeX = 5;
        public const int MaxSizeY = 5;
        
        private readonly int _rows;
        private readonly int _columns;
        public Card(int rows, int columns)
        {
            //  Validate against MaxSizeX and MaxSizeY
        }
        ...
        public int Rows { get { return _rows; } }
        public int Columns { get { return _columns; } } 
    }
