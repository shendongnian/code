        public class BulbBatchListViewModel
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        ///<summary>
        /// order field
        /// </summary>
        public string Sort { get; set; }
        public string SortDir { get; set; }
        /// <summary>
        /// fields for searching
        /// </summary>
        public string BulbName { get; set; }
        public string BarCode { get; set; }
        public string LocationName { get; set; }
        /// <summary>
        /// we are using IPageList instead of IEnumerable to create pagination on the view
        /// </summary>
        //public IPagedList<BulbBatchViewModel> SearchResult { get; set; }
        public List<BulbBatchViewModel> SearchResult { get; set; }
        public string SearchButton { get; set; }
        public string ClearButton { get; set; }
        public BulbBatchListViewModel()
        {
            Page = 1;
            PageSize = 5;
            Sort = "BulbBatchID";
            SortDir = "ASC";
        }
    }
