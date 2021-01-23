    public class BasicItem {
    public Geopoint Geopoint { get; set; }
        public BasicItem(double lat , double lng)
        {
            
            Geopoint = new Geopoint(new BasicGeoposition() { Latitude = lat, Longitude = lng });
        }
     }
