    public class Show
    {
        public int ID { get; set; }
        public int MovieID { get; set; }
        public int TheaterID { get; set; }
        public DateTime StartTime { get; set; }
        public string BookingLink { get; set; }
        public string StartTimeAsString { get; set; }
        public Movie Movie { get; set; }
        public Theater Theater { get; set; }
        public IEnumerable<SelectListItem> Theatres { get; set; }
        public IEnumerable<SelectListItem> Moview { get; set; }
    }
