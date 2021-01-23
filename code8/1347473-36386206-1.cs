    public class VisitorsViewModel
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public ICollection<VisitViewModel> Visits { get; set; }
    }
