    [JsonObject]
        public class Polygon : IEnumerable<Point>{
            public List<Point> Vertices { get; set; }
            public AxisAlignedRectangle Envelope { get; set; }
    
            ...
            public bool ShouldSerializeEnvelope() {
                return !(this is AxisAlignedRectangle);
            }
    
        }
