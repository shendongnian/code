    public class PhotoInfo
    {
        public String Label { get; set; }
        public String FileName { get; set; }
        public Geocoordinate Coordinate { get; set; }
        public Point NormalizedAnchorPoint { get { return new Point(0.5, 1); } }
    }
