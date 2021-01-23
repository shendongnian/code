    public class MyViewModel
    {
        [Display(Name = "Select size" )]
        [Required(ErrorMessage = "Please select a size")]
        public int ProductID { get; set; }
        public IEnumerable<SelectListItem> AvailableSizes { get; set; }
        public string ReturnUrl { get; set; }
    }
