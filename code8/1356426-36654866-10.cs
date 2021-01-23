    public class Size 
    {
        private readonly double _width;
        private readonly double _height;
        private readonly Unit _unit;
        public Size(double width, double height, Unit unit)
        {
            _width = width;
            _height = height;
            _unit = unit;
        }
        public double Width => _width;
        public double Height => _height;
        public Unit Unit => _unit;
    }
