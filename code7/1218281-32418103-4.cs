    public class Banner
    {    
        //other columns..
        public IList<BannersInPages> Pages{get;set;}   
    }
    
    public class Page
    {   
        //other columns..    
        public IList<BannersInPages> Banners{get;set;}   
    }
   
    public class BannersInPages    
    {
        public int BannerId{get;set;}
        public int PageId{get;set;}
        public int BannerSortOrder{get;set;}
        public string Placement {get;set;} 
       // add these navigation properties too if you want (recommended)
       public virtual Banner{get;set;}
       public virtual Page{get;set} 
    }
