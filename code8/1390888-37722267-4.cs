    public class FranchaiseVM
    {
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }
        .... // copy other properties of Franchaise that you want to edit
        public int Status { get; set; }
        public IEnumerable<SelectListItem> StatusList { get; set; }
        public IEnumerable<Franchaise> Franchaises { get; set; }
    }
