    //using System.Collections.Generic;
    public class GeoCoordinates
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
    public class POIData
    {
        public string ShortText { get; set; }
        public GeoCoordinates GeoCoordinates { get; set; }
        public List<string> Images { get; set; }
    }
