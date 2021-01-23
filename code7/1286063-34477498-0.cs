    public class TaskInstanceViewModel
    {
        [DataType(DataType.DateTime)]
        public DateTime DueDate { get; set; }
        public int HowMany { get; set; }
        public IEnumerable<SelectListItem> TaskList { get; set; }
        public int SelectedTask {set;get;} // new property
        // Keep only those properties needed for the view.
    }
