    public class MyViewModel
    {
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string BranchType { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }
        public IEnumerable<SelectListItem> CompanyNames { get; set; }
        public IEnumerable<SelectListItem> BranchTypes { get; set; }
    }
