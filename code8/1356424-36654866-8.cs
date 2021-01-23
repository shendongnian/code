    public class Size 
    {
        private readonly double _width;
        private readonly double _height;
        public Size(double width, double height)
        {
            _width = width;
            _height = height;
        }
        public double Width => _width;
        public double Height => _height;
    }
