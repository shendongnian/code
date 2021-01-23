    public class ResultType
    {
        public string RouteID { get; set; }
        public List<GeoTunnelPoints> Points { get; set; }
        public double TMiles { get; set; }
        public ResultType()
        {
            RouteID = "";
            Points = new List<GeoTunnelPoints>();
            TMiles = 0;
        }
    }
    public class GeoTunnelPoints
    {
        double Lat { get; set; }
        double Lon { get; set; }
        public GeoTunnelPoints()
        {
            Lat = 0.0;
            Lon = 0.0;
        }
    }
