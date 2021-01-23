    public class IndexViewModel
    {
        public IndexViewModel()
        {
            AvailableCars = new List<SelectListItem>();
        }
    
        public int PersonID { get; set; }
    
        public string Name { get; set; }
    
        public int SelectedCarId { get; set; }
    
        public IList<SelectListItem> AvailableCars { get; set; }
    }
