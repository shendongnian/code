    public class HomeModel
    {
        public IList<string> SelectedFruits { get; set; }
        public IList<SelectListItem> AvailableFruits { get; set; }
    
        public HomeModel()
        {
            SelectedFruits = new List<string>();
            AvailableFruits = new List<SelectListItem>();
        }
    }
