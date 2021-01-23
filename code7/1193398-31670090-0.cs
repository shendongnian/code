    public class Datum
    {
        public string cat_id { get; set; }
        public string category { get; set; }
        public string img_url { get; set; }
    }
    
    public class RootObject
    {
        public List<Datum> data { get; set; }
    }
