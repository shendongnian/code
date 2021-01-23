    public class MyViewModel
    {
        public string CompanyName { get; set; }
        public string BranchType { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }
        public IEnumerable<SelectListItem> CompanyNames { get; set; }
        public IEnumerable<SelectListItem> BranchTypes { get; set; }
    }
