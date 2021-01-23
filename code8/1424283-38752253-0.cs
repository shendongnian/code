    public class ShowData
    {
        public List<Show> Shows { get; set; }
    }
    
    public class Show
    {
        public string[] aliases { get; set; }
        public string banner { get; set; }
        public string firstAired { get; set; }
        public int id { get; set; }
        public string network { get; set; }
        public string overview { get; set; }
        public string seriesName { get; set; }
        public string status { get; set; }
    }
