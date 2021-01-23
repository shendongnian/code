    public class VM
    {
        public int ID {get;set}
        public student Students {get;set;}
            
        public List<SelectListItem> SiteList {get;set;}
        public int SiteID {get;set;}
            
        public DateTime Date  { get { return DateTime.Now; } }
        public bool Criteria {get;set;}
    }
