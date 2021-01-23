    public class ScheduleViewModel
    {
        public DateTime? SelectedDate { get; set; }
        public IEnumerable<SelectListItem> Values { get; set; }       
        public Schedule OneSchedule { get; set; }
    }
