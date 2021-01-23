    public class Coordinate
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
    
    public class RootObject
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public List<Coordinate> Coordinates { get; set; }
        public int Type { get; set; }
        public int LayerId { get; set; }
    }
