    public class Column {
        public string Name;
        public string Type;
        public object Content;
        
        public GeoPoint ToGeoPoint() {
            GeoPoint point = new GeoPoint();
            point.Name = this.Name;
            point.Type = this.Type;
            point.Content = this.Content;
            return point;
        }
    }
