    //This all makes sense as instance methods because you're 
    //encapsulating logic MyPoint is concerned with.
    public class MyPoint
    {
        public double x { get; set; }
        public double y { get; set; }
        public double? DistanceFrom(MyPoint p)
        {
            if (p != null)
                return  Math.Sqrt(Math.Pow(this.x - p.x, 2) + Math.Pow(this.y - p.y, 2));            
            return null;
        }
    }
