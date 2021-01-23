        public class PagingViewModel
        {
            public string SortBy { get; set; }
    
            public bool SortDesc { get; set; }
    
            public int CurrentPage { get; set; }
    
            public int TotalItems { get; set; }
    
            public int ItemsPerPage { get; set; }
    
            public int TotalPages
            {
                get
                {
                    if (this.ItemsPerPage > 0)
                        return (int) Math.Ceiling((decimal) TotalItems/this.ItemsPerPage);
                    else
                        return 1;
                }
            }
    
            public override string ToString()
            {
                return string.Format("PagingViewModel(SortBy='{0}',SortDesc='{1}', CurrentPage='{2}', TotalItems='{3}', ItemsPerPage='{4}')",
                    SortBy, SortDesc, CurrentPage, TotalItems, ItemsPerPage);
            }
        }
