    public class TaskInstanceViewModel
    {       
        public DateTime DueDate { get; set; }
        public int HowMany { get; set; }
        public IEnumerable<SelectListItem> TaskList { get; set; }
        public int SelectedTask {set;get;} // new property
    }
