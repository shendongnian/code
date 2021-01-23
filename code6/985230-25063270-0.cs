    public class Image
    {
        public string full { get; set; }
    }
    public class Annotations
    {
        public string source_continent { get; set; }
        public string source_cat { get; set; }
        public string source_neighborhood { get; set; }
        public string source_state { get; set; }
        public string source_loc { get; set; }
        public string source_subloc { get; set; }
        public string source_map_google { get; set; }
        public string source_map_yahoo { get; set; }
        public string latlong_source { get; set; }
        public string proxy_ip { get; set; }
        public string source_heading { get; set; }
        public string phone { get; set; }
        public string source_account { get; set; }
        public string original_posting_date { get; set; }
        public string source_subcat { get; set; }
        public string condition { get; set; }
    }
    public class Location
    {
        public string country { get; set; }
        public string state { get; set; }
        public string metro { get; set; }
        public string region { get; set; }
        public string county { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public string lat { get; set; }
        public string @long { get; set; }
        public int accuracy { get; set; }
        public int geolocation_status { get; set; }
    }
    public class Posting
    {
        public int id { get; set; }
        public string external_url { get; set; }
        public string heading { get; set; }
        public string body { get; set; }
        public int timestamp { get; set; }
        public int price { get; set; }
        public List<Image> images { get; set; }
        public Annotations annotations { get; set; }
        public Location location { get; set; }
    }
    public class RootObject
    {
        public bool success { get; set; }
        public int anchor { get; set; }
        public List<Posting> postings { get; set; }
    }
