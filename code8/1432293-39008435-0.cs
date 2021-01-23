    public class Rootobject
    {
        public Result[] results { get; set; }
        public string status { get; set; }
    }
    public class Result
    {
        public Address_Components[] address_components { get; set; }
        public string formatted_address { get; set; }
        public Geometry geometry { get; set; }
        public string place_id { get; set; }
        public string[] types { get; set; }
    }
    (...)
