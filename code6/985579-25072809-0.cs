    public class Coord
    {
        public double Zone {get; set;}
        public List<double> EastNorth {get; set;}
        public Coord()
        {
            EastNorth = new List<double>();
        }
    }
