    public class IndexViewModel
    {
        public IList<SelectListItem> Races { get; set; }
        public int raceSelected { get; set; }
        public IList<SelectListItem> PageSize { get; set; }
        public int pageSizeSelected { get; set; }
    }
