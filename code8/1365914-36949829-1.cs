    public class VaraVM
    {
        public int? ID { get; set; }
        ....
        [Display(Name = "Category")]
        [Required(ErrorMessage = "Please select a category")]
        public int SelectedCategory { get; set; }
        public IEnumerable<SelectistItem> CategoryList { get; set; }   
    }
