    public class Card : ICard
    {    
        ...
        public const int MaxRows = 5;
        public const int MaxColumns = 5;
        
        private readonly int _rows;
        private readonly int _columns;
        public Card(int rows, int columns)
        {
            if(columns > MaxColumns || rows > MaxRows) 
            {
                throw new ArgumentExcetion(...);
            }
        }
        ...
        public int Rows { get { return _rows; } }
        public int Columns { get { return _columns; } } 
    }
