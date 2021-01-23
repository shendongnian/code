    public class Card : ICard
    {    
        ...
        public const int MaxSizeX = 5;
        public const int MaxSizeY = 5;
        
        public Card(int sizeX, int sizeY)
        {
            //  Validate against MaxSizeX and MaxSizeY
        }
        ...
        
    }
