    public class PageConfig
    {
        public int Id {get;set;}
        //navigation property
        public ICollection<Image> ScrollerImages {get;set;}
    }
    public class Image 
    {
        public int Id {get;set;}
        //FK
        public int? PageConfigId {get;set;}
        //navigation property
        public PageConfig PageConfig {get;set;}
    }
