    public class RegisterViewModel
    {
        ....
        [Display(Name = "Wireless Carrier")]
        [Required(ErrorMessage = "Please select a carrier")]
        public int SelectedCarrier { get; set; }
        public IEnumerable<SelectListItem> CarrierList { get; set; }
    }
