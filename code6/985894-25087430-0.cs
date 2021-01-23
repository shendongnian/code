    public struct CircleF : IEquatable<CircleF>
    {
        public CircleF(PointF center, float radius);
        public double Area { get; }
        public PointF Center { get; set; }
        [XmlAttribute("Radius")]
        public float Radius { get; set; }
        public bool Equals(CircleF circle2);
    }
