    public class MapItem {
    public Geopoint Geopoint { get; set; }
        public MapItem(double lat , double lng)
        {
            
            Geopoint = new Geopoint(new BasicGeoposition() { Latitude = lat, Longitude = lng });
         }
    }
