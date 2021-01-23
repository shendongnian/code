    public class AddressViewModel
    {
        
        [Display(Name = "Country")]
        public int SelectedCountryId { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }
    }
