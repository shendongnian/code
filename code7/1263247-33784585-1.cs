    public class EditWeightsViewModel
    {
        public string SelectedWeek {set;get;}
        [DisplayName("Week")]
        public List<SelectListItem> WeeksOfEntryList { get; set; }          
    
        [DisplayName("Associates")]
        public SelectList AssociatesList { get; set; }
        public decimal Weight { get; set; }
    }
