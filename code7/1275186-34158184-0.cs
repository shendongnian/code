    public class Details
    {
        public string timestamp { get; set; }
        public string reference { get; set; }
    }
    public class SendDetails : Details
    {
        public string id { get; set; }
        public string correlator { get; set; }
        public string device1 { get; set; }
        public string device2 { get; set; }
        public string device3 { get; set; }
    }
    public class ReceiveDetails : Details
    {
        public string primaryid { get; set; }
        public string primary_correlator { get; set; }
        public string secondaryid { get; set; }
        public string secondary_correlator { get; set; }
        public string device4 { get; set; }
        public string device5 { get; set; }
    }
