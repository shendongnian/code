    [JsonObject]
    public class Polygon : IEnumerable<Point>
    {
        public List<Point> Vertices { get; set; }
        public AxisAlignedRectangle Envelope { get; set; }
        public virtual bool ShouldSerializeEnvelope()
        {
            return true;
        }
    }
    public class AxisAlignedRectangle : Polygon
    {
        public double Left { get; set; }
        ...
        public override bool ShouldSerializeEnvelope()
        {
            return false;
        }
    }
