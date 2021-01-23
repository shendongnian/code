    class Point : ITranslate
    {
        public Point(int x, int y)
        {
            Y = y;
            X = x;
        }
    
        public int X { get; private set; }
        public int Y { get; private set; }
    
        public Point Translate(Translation translation)
        {
            //return a new translated point
        }
    }
