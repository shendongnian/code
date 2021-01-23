    public class TimeReportVM
    {
        [Display(Name = "Find by name")]
        public string SearchString { get; set; }
        public string SortOrder { get; set; }
        [Display(Name = "Select page size")]
        public int PageSize { get; set; }
        public SelectList PageSizeList { get; set; }
        public IPagedList<User> Users { get; set; }
    }
