    public class ProductVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        ....
        [Display(Name = "Select size" )]
        [Required(ErrorMessage = "Please select a size")]
        public int SelectedSize { get; set; }
        public IEnumerable<SelectListItem> AvailableSizes { get; set; }
        public string ReturnUrl { get; set; }
    }
