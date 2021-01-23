    public class ViewModel
    {
        public ViewModel() {}
    
        // These are the options lists..
        public List<SelectListItem> ListItem1 { get; set; }
        public List<SelectListItem> ListItem2 { get; set; }
    
        // These are user selections..
        public List<string> SelectedListItems1 { get; set; }
        public List<string> SelectedListItems2 { get; set; }
    }
