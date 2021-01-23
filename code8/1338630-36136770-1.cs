    class Point : ITranslate
    {
        public Point(int x, int y)
        {
            Y = y;
            X = x;
        }
    
        public int X { get; private set; }
        public int Y { get; private set; }
    
        public void Translate(Translation translation)
        {
            //apply the translation to myself internally on my X and Y
        }
    }
