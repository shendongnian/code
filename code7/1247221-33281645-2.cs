    public class MovieAndTheaterViewModel
    {
        public int MovieID { get; set; }
        public int TheaterID { get; set; }
        public IEnumerable<SelectListItem> Movies { get; set; }
        public IEnumerable<SelectListItem> Theatres { get; set; }
    }
    
