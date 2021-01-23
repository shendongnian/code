    public class Artist
    {
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string image_url { get; set; }
        public string thumb_url { get; set; }
        public string large_image_url { get; set; }
        public bool on_tour { get; set; }
        public string events_url { get; set; }
        public string sony_id { get; set; }
        public int tracker_count { get; set; }
        public bool verified { get; set; }
        public int media_id { get; set; }
    }
    
    public class Venue
    {
        public string name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string country { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
    
    public class Event
    {
        public string id { get; set; }
        public string artist_event_id { get; set; }
        public string title { get; set; }
        public string datetime { get; set; }
        public string formatted_datetime { get; set; }
        public string formatted_location { get; set; }
        public string ticket_url { get; set; }
        public string ticket_type { get; set; }
        public string ticket_status { get; set; }
        public string on_sale_datetime { get; set; }
        public string facebook_rsvp_url { get; set; }
        public string description { get; set; }
        public List<Artist> artists { get; set; }
        public Venue venue { get; set; }
        public string facebook_event_id { get; set; }
        public int rsvp_count { get; set; }
        public int? media_id { get; set; }
    }
    
    public class Data
    {
        public List<Event> events { get; set; }
    }
    
    public class Pages
    {
        public int current_page { get; set; }
        public int total_results { get; set; }
        public int results_per_page { get; set; }
        public string next_page_url { get; set; }
        public object previous_page_url { get; set; }
    }
    
    public class PopularEvents
    {
        public Data data { get; set; }
        public Pages pages { get; set; }
    }
