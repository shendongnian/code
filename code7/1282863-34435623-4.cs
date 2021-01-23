    public static class Namespaces
    {
        public const string Pcmiler = @"http://pcmiler.alk.com/APIs/v1.0";
    }
    [DataContract(Namespace = Namespaces.Pcmiler)]
    public class Coordinates
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
    }
    [KnownType(typeof(CalculateMilesReport))]
    [KnownType(typeof(GeoTunnelReport))]
    [DataContract(Namespace = Namespaces.Pcmiler)]
    public abstract class Report
    {
        [DataMember]
        public string RouteID { get; set; }
    }
    [DataContract(Namespace = Namespaces.Pcmiler)]
    public class CalculateMilesReport : Report
    {
        [DataMember]
        public double TMiles { get; set; }
    }
    [DataContract(Namespace = Namespaces.Pcmiler)]
    public class GeoTunnelReport : Report
    {
        [DataMember]
        public List<Coordinates> GeoTunnelPoints { get; set; }
    }
