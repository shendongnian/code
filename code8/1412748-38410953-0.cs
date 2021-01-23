    public class Rectangle:ICalculatingArea
    {
        public double Width {get; set;}
        public double Length {get; set;}
        public double CalculateArea()
        {
            return Length * Width;
        }
    }
