    public class Page
    {
        public int Id { get; set; }
        public string PageURL { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public virutal IQueriable<Visit> Visits { get; set; }    
    }
    public class Visit
    {
     // ...  properties related to data you wish to retain about the visit
    public Page Page { get; set; } // navigation property
    }
