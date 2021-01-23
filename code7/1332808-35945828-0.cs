    public class Page
        {
            public int PageId { get; set; }
    
            public string PageTitle { get; set; }
    
            public Page Parent { get; set; }
        }
    
        public class Class1
        {
            public List<Page> GetPages(Page currentPage)
            {
                var ret = new List<Page> {currentPage};
                if(currentPage.Parent != null)
                    ret.AddRange(GetPages(currentPage.Parent));
                return ret;
            } 
        }
