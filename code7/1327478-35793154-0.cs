    public class AnouncementVM
    {
        public string Title { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Date { get; set; }
        public string Category { get; set; }
    }
