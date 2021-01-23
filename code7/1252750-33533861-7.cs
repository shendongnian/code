    public class MapItem {
    public Geopoint Geopoint { get; set; }
    public string image {get; set;}
        public MapItem(double lat , double lng , string img)
        {
            
            Geopoint = new Geopoint(new BasicGeoposition() { Latitude = lat, Longitude = lng });
            image=img;
         }
    }
