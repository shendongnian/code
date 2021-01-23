    public class MyViewModel
    {
        public IEnumerable<SelectListItem> MemberAdminOrMajors { get; set; }
        public IEnumerable<SelectListItem> MemberBMs { get; set; }
        public int SelectedAdmin {get; set;}
        public int SelectedBM {get; set; }
  
        // other data
    }
