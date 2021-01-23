    public class LeaveTypeVM
    {
        [Required(ErrorMessage = "Please select a leave type")]
        public int SelectedLeaveType { get; set; }
        public IEnumerable<SelectListItem> LeaveTypeList { get; set; }
    }
